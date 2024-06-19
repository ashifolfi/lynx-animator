using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml;

namespace LibXfl;

public struct DomFillStyle()
{
    public byte[] Color = [0, 0, 0];
    public float Alpha = 1;
}

public struct DomStrokeStyle
{
    // todo: get more test data to check what stroke style contains
}

public struct DomVectorEdge()
{
    /// <summary>
    /// Left side of the edge
    /// </summary>
    public int FillStyle0 = 0;
    /// <summary>
    /// Right side of the edge
    /// </summary>
    public int FillStyle1 = 0;
    public int StrokeStyle = 0;

    public List<DomShape.VectorCommand> Commands = [];
    // Note: Cubic is not included, the data appears to be internal flash data.
}

public partial class DomShape : IDomFrameElement
{
    private const char XflVecCmdMoveTo = '!';
    private const char XflVecCmdLineTo = '|';
    private const char XflVecCmdQuatTo = '[';
    // todo: add hex position support
    private const char XflVecPosHex = '#';
    
    public IDomFrameElement.ElementType Type => IDomFrameElement.ElementType.Shape;

    [GeneratedRegex(@"(?<Point>(?<PX>\d+)\s+(?<PY>\d+))")]
    private static partial Regex PointRegex();

    [GeneratedRegex(@"(S[1|2|4])")]
    private static partial Regex SelectionHintRegex();

    public struct VectorCommand
    {
        public enum CommandType
        {
            MoveTo,
            LineTo,
            QuadraticTo
        }

        public CommandType Type;
        public Vector2 Point1;
        public Vector2 Point2;
    }
    
    public List<DomVectorEdge> Edges = [];
    public Dictionary<int, DomStrokeStyle> StrokeStyles = new();
    public Dictionary<int, DomFillStyle> FillStyles = new();

    /// <summary>
    /// Blank Constructor for a new DomShape object
    /// </summary>
    public DomShape()
    {
    }

    /// <summary>
    /// Construct DomShape object from XFL XML Data
    /// </summary>
    /// <param name="shapeNode"></param>
    public DomShape(XmlNode shapeNode)
    {
        var strokeListNode = shapeNode.SelectSingleNode("*[local-name() = 'strokes']");
        if (strokeListNode != null)
        {
        }

        var fillListNode = shapeNode.SelectSingleNode("*[local-name() = 'fills']");
        if (fillListNode != null)
        {
        }

        var edgeListNode = shapeNode.SelectSingleNode("*[local-name() = 'edges']");
        if (edgeListNode != null)
        {
            var edges = edgeListNode.SelectNodes("*[local-name() = 'Edge']");

            if (edges == null)
            {
                return;
            }

            foreach (XmlNode edge in edges)
            {
                if (edge.Attributes?["cubics"] != null)
                {
                    continue;
                }

                var domEdge = new DomVectorEdge();

                var fillStyle0 = edge.Attributes?["fillStyle0"]?.Value;
                if (fillStyle0 != null)
                    domEdge.FillStyle0 = Convert.ToInt32(fillStyle0);

                var fillStyle1 = edge.Attributes?["fillStyle1"]?.Value;
                if (fillStyle1 != null)
                    domEdge.FillStyle1 = Convert.ToInt32(fillStyle1);

                var strokeStyle = edge.Attributes?["strokeStyle"]?.Value;
                if (strokeStyle != null)
                    domEdge.StrokeStyle = Convert.ToInt32(strokeStyle);

                var cmdString = edge.Attributes?["edges"]?.Value;
                if (cmdString != null)
                    domEdge.Commands = ReadCommandString(cmdString);

                Edges.Add(domEdge);
            }
        }
    }

    List<VectorCommand> ReadCommandString(string cmdString)
    {
        List<VectorCommand> commands = [];

        // strip out IDE Hints
        var sCmdString = SelectionHintRegex().Replace(cmdString, "");

        var pointRegex = PointRegex();
        for (var i = 0; i < sCmdString.Length; i++)
        {
            switch (sCmdString[i])
            {
                case XflVecCmdMoveTo:
                {
                    var command = new VectorCommand();

                    var point = Vector2.Zero;

                    i++; // increment past marker
                    var pointMatch = pointRegex.Match(sCmdString.Substring(i, sCmdString.Length - i));

                    // place point value into Vector2
                    point.X = float.Parse(pointMatch.Groups["PX"].Value);
                    point.Y = float.Parse(pointMatch.Groups["PY"].Value);

                    command.Type = VectorCommand.CommandType.MoveTo;
                    command.Point1 = point;
                    commands.Add(command);
                    break;
                }
                case XflVecCmdLineTo:
                {
                    var command = new VectorCommand();

                    var point = Vector2.Zero;

                    i++; // increment past marker
                    var pointMatch = pointRegex.Match(sCmdString.Substring(i, sCmdString.Length - i));

                    // place point value into Vector2
                    point.X = float.Parse(pointMatch.Groups["PX"].Value);
                    point.Y = float.Parse(pointMatch.Groups["PY"].Value);

                    command.Type = VectorCommand.CommandType.LineTo;
                    command.Point1 = point;
                    commands.Add(command);
                    break;
                }
                case XflVecCmdQuatTo:
                {
                    var command = new VectorCommand();

                    var controlPoint = Vector2.Zero;
                    var point = Vector2.Zero;

                    i++; // increment past marker
                    var controlPointMatch = pointRegex.Match(sCmdString.Substring(i, sCmdString.Length - i));

                    // place point value into Vector2
                    controlPoint.X = float.Parse(controlPointMatch.Groups["PX"].Value);
                    controlPoint.Y = float.Parse(controlPointMatch.Groups["PY"].Value);

                    var pointMatch =
                        pointRegex.Match(sCmdString.Substring(i + controlPointMatch.Length,
                                                             sCmdString.Length - (i + controlPointMatch.Length)));
                    point.X = float.Parse(pointMatch.Groups["PX"].Value);
                    point.Y = float.Parse(pointMatch.Groups["PY"].Value);

                    command.Type = VectorCommand.CommandType.QuadraticTo;
                    command.Point1 = controlPoint;
                    command.Point2 = point;
                    commands.Add(command);
                    break;
                }
            }
        }

        return commands;
    }
}
