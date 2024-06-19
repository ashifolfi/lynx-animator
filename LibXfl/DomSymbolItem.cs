using System.Xml;

namespace LibXfl;

public class DomSymbolItem
{
    public string Name = "";
    public string ItemId = "";
    public string SourceLibraryItemHRef = "";
    public long LastModified = 0;
    public string SymbolType = "";
    
    public DomTimeline Timeline = new();

    public DomSymbolItem()
    {
    }
    
    public DomSymbolItem(XmlNode node)
    {
        var nameValue = node.Attributes?["name"]?.Value;
        if (nameValue != null)
            Name = nameValue;
        
        var itemIdValue = node.Attributes?["itemID"]?.Value;
        if (itemIdValue != null)
            ItemId = itemIdValue;
        
        var sourceLibraryItemHRefValue = node.Attributes?["sourceLibraryItemHRef"]?.Value;
        if (sourceLibraryItemHRefValue != null)
            SourceLibraryItemHRef = sourceLibraryItemHRefValue;
        
        var lastModifiedValue = node.Attributes?["lastModified"]?.Value;
        if (lastModifiedValue != null)
            LastModified = Convert.ToInt64(lastModifiedValue);
        
        var timelineNode = node.SelectSingleNode("*[local-name() = 'timeline']")?.FirstChild;
        if (timelineNode != null)
            Timeline = new DomTimeline(timelineNode);
    }
}
