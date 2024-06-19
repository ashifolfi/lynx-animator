using System.Xml;

namespace LibXfl;

public class DomDocument
{
    // todo: where the hell are these stored in CS5?
    public int StageWidth;
    public int StageHeight;
    
    public List<SwatchGroup> SwatchGroups = [];
    public List<ExtendedSwatchGroup> SwatchGroupsExtended = [];
    public List<SymbolReference> Symbols = [];

    public struct SymbolReference
    {
        public string HRef;
        public int ItemIcon;
        public bool LoadImmediate;
    }
    
    public DomDocument()
    {
    }

    public DomDocument(XmlNode root)
    {
        // load the symbol references
        var symbolListNode = root.SelectSingleNode("*[local-name() = 'symbols']");
        if (symbolListNode != null)
        {
            foreach (XmlNode symbolRefNode in symbolListNode.ChildNodes)
            {
                var symbolRef = new SymbolReference();

                var hrefValue = symbolRefNode.Attributes?["href"]?.Value;
                if (hrefValue != null)
                    symbolRef.HRef = hrefValue;

                var itemIconValue = symbolRefNode.Attributes?["itemIcon"]?.Value;
                if (itemIconValue != null)
                    symbolRef.ItemIcon = Convert.ToInt32(itemIconValue);

                var loadImmediateValue = symbolRefNode.Attributes?["loadImmediate"]?.Value;
                if (loadImmediateValue != null)
                    symbolRef.LoadImmediate = Convert.ToBoolean(loadImmediateValue);
                
                Symbols.Add(symbolRef);
            }
        }
        
        // parse in our swatch groups
        var swatchListsNode = root.SelectSingleNode("*[local-name() = 'swatchLists']");
        if (swatchListsNode != null)
        {
            foreach (XmlNode swListNode in swatchListsNode.ChildNodes)
            {
                if (swListNode.LocalName != "swatchList")
                    continue;
                
                SwatchGroups.Add(new SwatchGroup(swListNode));
            }
        }
        
        var extSwatchListsNode = root.SelectSingleNode("*[local-name() = 'extendedSwatchLists']");
        if (extSwatchListsNode != null)
        {
            foreach (XmlNode swListNode in extSwatchListsNode.ChildNodes)
            {
                if (swListNode.LocalName != "swatchList")
                    continue;

                SwatchGroupsExtended.Add(new ExtendedSwatchGroup(swListNode));
            }
        }
    }
}
