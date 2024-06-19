using System.Xml;

namespace LibXfl;

public struct SwatchGroup
{
    public List<SolidSwatchItem> Swatches;

    public SwatchGroup()
    {
        Swatches = [];
    }

    public SwatchGroup(XmlNode listNode)
    {
        Swatches = [];
        
        var seList = listNode.SelectSingleNode("*[local-name() = 'swatches']");
        if (seList != null)
        {
            foreach (XmlNode swatchItem in seList.ChildNodes)
            {
                if (swatchItem.LocalName != "SolidSwatchItem")
                    continue;
            
                // initialize to defaults of black or 0
                var solidSwatchItem = new SolidSwatchItem
                {
                    Color = [0,0,0],
                    Hue = 0,
                    Saturation = 0,
                    Brightness = 0
                };

                var hexAttrVal = swatchItem.Attributes?["color"]?.Value;
                if (hexAttrVal != null)
                    solidSwatchItem.Color = Convert.FromHexString(hexAttrVal.Substring(1, hexAttrVal.Length - 1));
            
                var hueAttrVal = swatchItem.Attributes?["hue"]?.Value;
                if (hueAttrVal != null)
                    solidSwatchItem.Hue = Convert.ToInt32(hueAttrVal);
            
                var saturationAttrVal = swatchItem.Attributes?["saturation"]?.Value;
                if (saturationAttrVal != null)
                    solidSwatchItem.Saturation = Convert.ToInt32(saturationAttrVal);
            
                var brightnessAttrVal = swatchItem.Attributes?["brightness"]?.Value;
                if (brightnessAttrVal != null)
                    solidSwatchItem.Brightness = Convert.ToInt32(brightnessAttrVal);
            
                Swatches.Add(solidSwatchItem);
            }
        }
    }
}

public struct ExtendedSwatchGroup
{
    public List<GradientSwatchItem> Swatches;

    public ExtendedSwatchGroup()
    {
        Swatches = [];
    }
    
    public ExtendedSwatchGroup(XmlNode listNode)
    {
        Swatches = [];
        
        var seList = listNode.SelectSingleNode("*[local-name() = 'swatches']");
        if (seList != null)
        {
            foreach (XmlNode swatchItem in seList.ChildNodes)
            {
                if (!swatchItem.LocalName.Contains("GradientSwatchItem"))
                    continue;

                var gradientSwatchItem = new GradientSwatchItem();

                // idfk what this is but rider says it's good so uh
                // note: look up what the fuck a switch expression is
                gradientSwatchItem.Type = swatchItem.LocalName switch
                {
                    "LinearGradientSwatchItem" => GradientType.Linear,
                    "RadialGradientSwatchItem" => GradientType.Radial,
                    _ => gradientSwatchItem.Type
                };

                gradientSwatchItem.Entries = [];
                foreach (XmlNode gradientEntryNode in swatchItem.ChildNodes)
                {
                    if (gradientEntryNode.LocalName != "GradientEntry")
                        continue;
                    
                    // initialize to defaults of black or 0
                    var gradientEntry = new GradientEntry()
                    {
                        Color = [0,0,0],
                        Ratio = 0
                    };

                    var hexAttrVal = gradientEntryNode.Attributes?["color"]?.Value;
                    if (hexAttrVal != null)
                        gradientEntry.Color = Convert.FromHexString(hexAttrVal.AsSpan(1, hexAttrVal.Length - 1));
        
                    var ratioAttr = gradientEntryNode.Attributes?["ratio"]?.Value;
                    if (ratioAttr != null)
                        gradientEntry.Ratio = float.Parse(ratioAttr);
        
                    gradientSwatchItem.Entries.Add(gradientEntry);
                }
                
                Swatches.Add(gradientSwatchItem);
            }
        }
    }
    
}
