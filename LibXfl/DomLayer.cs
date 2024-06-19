using System.Xml;

namespace LibXfl;

public class DomLayer
{
    public string Name = "";
    public byte[] Color = [0, 0, 0];
    public bool Current = false;
    public bool IsSelected = false;
    
    public List<DomFrame> Frames = [];

    public DomLayer()
    {
    }

    public DomLayer(XmlNode node)
    {
        var nameValue = node.Attributes?["name"]?.Value;
        if (nameValue != null)
            Name = nameValue;
        
        var colorValue = node.Attributes?["color"]?.Value;
        if (colorValue != null)
            Color = Convert.FromHexString(colorValue.AsSpan(1, colorValue.Length - 1));
        
        var currentValue = node.Attributes?["current"]?.Value;
        if (currentValue != null)
            Current = Convert.ToBoolean(currentValue);
        
        var isSelectedValue = node.Attributes?["selected"]?.Value;
        if (isSelectedValue != null)
            IsSelected = Convert.ToBoolean(isSelectedValue);

        var framesNode = node.SelectSingleNode("*[local-name() = 'frames']");
        if (framesNode != null)
        {
            foreach (XmlNode frameNode in framesNode.ChildNodes)
            {
                Frames.Add(new DomFrame(frameNode));
            }
        }
    }
}
