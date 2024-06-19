using System.Xml;

namespace LibXfl;

public class DomFrame
{
    public int Index;
    public int KeyMode;
    public List<IDomFrameElement> Elements = [];

    public DomFrame()
    {
    }

    public DomFrame(XmlNode frameNode)
    {
        var indexValue = frameNode.Attributes?["index"]?.Value;
        if (indexValue != null)
            Index = Convert.ToInt32(indexValue);
        
        var keyModeValue = frameNode.Attributes?["keyMode"]?.Value;
        if (keyModeValue != null)
            KeyMode = Convert.ToInt32(keyModeValue);
        
        var elementsNode = frameNode.SelectSingleNode("*[local-name() = 'elements']");
        if (elementsNode != null)
        {
            foreach (XmlNode elementNode in elementsNode.ChildNodes)
            {
                switch (elementNode.LocalName)
                {
                    case "DOMShape":
                        Elements.Add(new DomShape(elementNode));
                        break;
                    case "DOMSymbolInstance":
                        throw new NotImplementedException();
                }
            }
        }
    }
}

public interface IDomFrameElement
{
    // todo: figure out what else can be listed under elements
    public enum ElementType
    {
        Shape,
        SymbolInstance
    }

    public ElementType Type { get; }
}
