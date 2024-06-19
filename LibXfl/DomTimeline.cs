using System.Xml;

namespace LibXfl;

public class DomTimeline
{
    public string Name = "";
    public List<DomLayer> Layers = [];

    public DomTimeline()
    {
    }
    
    public DomTimeline(XmlNode node)
    {
        var nameValue = node.Attributes?["name"]?.Value;
        if (nameValue != null)
            Name = nameValue;
        
        var layersNode = node.SelectSingleNode("*[local-name() = 'layers']");
        if (layersNode != null)
        {
            foreach (XmlNode layerNode in layersNode.ChildNodes)
            {
                Layers.Add(new DomLayer(layerNode));
            }
        }
    }
}
