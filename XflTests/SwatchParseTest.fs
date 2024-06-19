module XflTests.SwatchParseTest

open Xunit
open LibXfl
open System.Xml

[<Fact>]
let SwatchParseTest () =
    let SwatchString = """
<swatchList>
   <swatches>
        <SolidSwatchItem/>
        <SolidSwatchItem/>
        <SolidSwatchItem/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#003300" hue="80" saturation="239" brightness="24"/>
        <SolidSwatchItem color="#006600" hue="80" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#009900" hue="80" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#00CC00" hue="80" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#00FF00" hue="80" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#330000" saturation="239" brightness="24"/>
        <SolidSwatchItem color="#333300" hue="40" saturation="239" brightness="24"/>
        <SolidSwatchItem color="#336600" hue="60" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#339900" hue="67" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#33CC00" hue="70" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#33FF00" hue="72" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#660000" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#663300" hue="20" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#666600" hue="40" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#669900" hue="53" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#66CC00" hue="60" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#66FF00" hue="64" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#333333" brightness="48"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#000033" hue="160" saturation="239" brightness="24"/>
        <SolidSwatchItem color="#003333" hue="120" saturation="239" brightness="24"/>
        <SolidSwatchItem color="#006633" hue="100" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#009933" hue="93" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#00CC33" hue="90" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#00FF33" hue="88" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#330033" hue="200" saturation="239" brightness="24"/>
        <SolidSwatchItem color="#333333" brightness="48"/>
        <SolidSwatchItem color="#336633" hue="80" saturation="80" brightness="72"/>
        <SolidSwatchItem color="#339933" hue="80" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#33CC33" hue="80" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#33FF33" hue="80" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#660033" hue="220" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#663333" saturation="80" brightness="72"/>
        <SolidSwatchItem color="#666633" hue="40" saturation="80" brightness="72"/>
        <SolidSwatchItem color="#669933" hue="60" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#66CC33" hue="67" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#66FF33" hue="70" saturation="239" brightness="144"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#666666" brightness="96"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#000066" hue="160" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#003366" hue="140" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#006666" hue="120" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#009966" hue="107" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#00CC66" hue="100" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#00FF66" hue="96" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#330066" hue="180" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#333366" hue="160" saturation="80" brightness="72"/>
        <SolidSwatchItem color="#336666" hue="120" saturation="80" brightness="72"/>
        <SolidSwatchItem color="#339966" hue="100" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#33CC66" hue="93" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#33FF66" hue="90" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#660066" hue="200" saturation="239" brightness="48"/>
        <SolidSwatchItem color="#663366" hue="200" saturation="80" brightness="72"/>
        <SolidSwatchItem color="#666666" brightness="96"/>
        <SolidSwatchItem color="#669966" hue="80" saturation="48" brightness="120"/>
        <SolidSwatchItem color="#66CC66" hue="80" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#66FF66" hue="80" saturation="239" brightness="168"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#999999" brightness="144"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#000099" hue="160" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#003399" hue="147" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#006699" hue="133" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#009999" hue="120" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#00CC99" hue="110" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#00FF99" hue="104" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#330099" hue="173" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#333399" hue="160" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#336699" hue="140" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#339999" hue="120" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#33CC99" hue="107" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#33FF99" hue="100" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#660099" hue="187" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#663399" hue="180" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#666699" hue="160" saturation="48" brightness="120"/>
        <SolidSwatchItem color="#669999" hue="120" saturation="48" brightness="120"/>
        <SolidSwatchItem color="#66CC99" hue="100" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#66FF99" hue="93" saturation="239" brightness="168"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#CCCCCC" brightness="192"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#0000CC" hue="160" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#0033CC" hue="150" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#0066CC" hue="140" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#0099CC" hue="130" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#00CCCC" hue="120" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#00FFCC" hue="112" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#3300CC" hue="170" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#3333CC" hue="160" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#3366CC" hue="147" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#3399CC" hue="133" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#33CCCC" hue="120" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#33FFCC" hue="110" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#6600CC" hue="180" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#6633CC" hue="173" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#6666CC" hue="160" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#6699CC" hue="140" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#66CCCC" hue="120" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#66FFCC" hue="107" saturation="239" brightness="168"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#FFFFFF" brightness="240"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#0000FF" hue="160" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#0033FF" hue="152" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#0066FF" hue="144" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#0099FF" hue="136" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#00CCFF" hue="128" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#00FFFF" hue="120" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#3300FF" hue="168" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#3333FF" hue="160" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#3366FF" hue="150" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#3399FF" hue="140" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#33CCFF" hue="130" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#33FFFF" hue="120" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#6600FF" hue="176" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#6633FF" hue="170" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#6666FF" hue="160" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#6699FF" hue="147" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#66CCFF" hue="133" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#66FFFF" hue="120" saturation="239" brightness="168"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#FF0000" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#990000" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#993300" hue="13" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#996600" hue="27" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#999900" hue="40" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#99CC00" hue="50" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#99FF00" hue="56" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#CC0000" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC3300" hue="10" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC6600" hue="20" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC9900" hue="30" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CCCC00" hue="40" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CCFF00" hue="48" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF0000" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF3300" hue="8" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF6600" hue="16" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF9900" hue="24" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FFCC00" hue="32" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FFFF00" hue="40" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#00FF00" hue="80" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#990033" hue="227" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#993333" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#996633" hue="20" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#999933" hue="40" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#99CC33" hue="53" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#99FF33" hue="60" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#CC0033" hue="230" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC3333" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CC6633" hue="13" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CC9933" hue="27" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CCCC33" hue="40" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CCFF33" hue="50" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF0033" hue="232" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF3333" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF6633" hue="10" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF9933" hue="20" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FFCC33" hue="30" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FFFF33" hue="40" saturation="239" brightness="144"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#0000FF" hue="160" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#990066" hue="213" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#993366" hue="220" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#996666" saturation="48" brightness="120"/>
        <SolidSwatchItem color="#999966" hue="40" saturation="48" brightness="120"/>
        <SolidSwatchItem color="#99CC66" hue="60" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#99FF66" hue="67" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#CC0066" hue="220" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC3366" hue="227" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CC6666" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#CC9966" hue="20" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#CCCC66" hue="40" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#CCFF66" hue="53" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FF0066" hue="224" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF3366" hue="230" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF6666" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FF9966" hue="13" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FFCC66" hue="27" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FFFF66" hue="40" saturation="239" brightness="168"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#FFFF00" hue="40" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#990099" hue="200" saturation="239" brightness="72"/>
        <SolidSwatchItem color="#993399" hue="200" saturation="120" brightness="96"/>
        <SolidSwatchItem color="#996699" hue="200" saturation="48" brightness="120"/>
        <SolidSwatchItem color="#999999" brightness="144"/>
        <SolidSwatchItem color="#99CC99" hue="80" saturation="80" brightness="168"/>
        <SolidSwatchItem color="#99FF99" hue="80" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#CC0099" hue="210" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC3399" hue="213" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CC6699" hue="220" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#CC9999" saturation="80" brightness="168"/>
        <SolidSwatchItem color="#CCCC99" hue="40" saturation="80" brightness="168"/>
        <SolidSwatchItem color="#CCFF99" hue="60" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#FF0099" hue="216" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF3399" hue="220" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF6699" hue="227" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FF9999" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#FFCC99" hue="20" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#FFFF99" hue="40" saturation="239" brightness="192"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#00FFFF" hue="120" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#9900CC" hue="190" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#9933CC" hue="187" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#9966CC" hue="180" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#9999CC" hue="160" saturation="80" brightness="168"/>
        <SolidSwatchItem color="#99CCCC" hue="120" saturation="80" brightness="168"/>
        <SolidSwatchItem color="#99FFCC" hue="100" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#CC00CC" hue="200" saturation="239" brightness="96"/>
        <SolidSwatchItem color="#CC33CC" hue="200" saturation="144" brightness="120"/>
        <SolidSwatchItem color="#CC66CC" hue="200" saturation="120" brightness="144"/>
        <SolidSwatchItem color="#CC99CC" hue="200" saturation="80" brightness="168"/>
        <SolidSwatchItem color="#CCCCCC" brightness="192"/>
        <SolidSwatchItem color="#CCFFCC" hue="80" saturation="239" brightness="216"/>
        <SolidSwatchItem color="#FF00CC" hue="208" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF33CC" hue="210" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF66CC" hue="213" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FF99CC" hue="220" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#FFCCCC" saturation="239" brightness="216"/>
        <SolidSwatchItem color="#FFFFCC" hue="40" saturation="239" brightness="216"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#FF00FF" hue="200" saturation="239" brightness="120"/>
        <SolidSwatchItem/>
        <SolidSwatchItem color="#9900FF" hue="184" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#9933FF" hue="180" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#9966FF" hue="173" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#9999FF" hue="160" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#99CCFF" hue="140" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#99FFFF" hue="120" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#CC00FF" hue="192" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#CC33FF" hue="190" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#CC66FF" hue="187" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#CC99FF" hue="180" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#CCCCFF" hue="160" saturation="239" brightness="216"/>
        <SolidSwatchItem color="#CCFFFF" hue="120" saturation="239" brightness="216"/>
        <SolidSwatchItem color="#FF00FF" hue="200" saturation="239" brightness="120"/>
        <SolidSwatchItem color="#FF33FF" hue="200" saturation="239" brightness="144"/>
        <SolidSwatchItem color="#FF66FF" hue="200" saturation="239" brightness="168"/>
        <SolidSwatchItem color="#FF99FF" hue="200" saturation="239" brightness="192"/>
        <SolidSwatchItem color="#FFCCFF" hue="200" saturation="239" brightness="216"/>
        <SolidSwatchItem color="#FFFFFF" brightness="240"/>
   </swatches>
</swatchList>
"""
    let ExtendedSwatchString = """
<swatchList>
     <swatches>
          <LinearGradientSwatchItem>
               <GradientEntry color="#FFFFFF" ratio="0"/>
               <GradientEntry ratio="1"/>
          </LinearGradientSwatchItem>
          <RadialGradientSwatchItem>
               <GradientEntry color="#FFFFFF" ratio="0"/>
               <GradientEntry ratio="1"/>
          </RadialGradientSwatchItem>
          <RadialGradientSwatchItem>
               <GradientEntry color="#FF0000" ratio="0"/>
               <GradientEntry ratio="1"/>
          </RadialGradientSwatchItem>
          <RadialGradientSwatchItem>
               <GradientEntry color="#00FF00" ratio="0"/>
               <GradientEntry ratio="1"/>
          </RadialGradientSwatchItem>
          <RadialGradientSwatchItem>
               <GradientEntry color="#0000FF" ratio="0"/>
               <GradientEntry ratio="1"/>
          </RadialGradientSwatchItem>
          <LinearGradientSwatchItem>
               <GradientEntry color="#0066FD" ratio="0"/>
               <GradientEntry color="#FFFFFF" ratio="0.376470588235294"/>
               <GradientEntry color="#FFFFFF" ratio="0.47843137254902"/>
               <GradientEntry color="#996600" ratio="0.501960784313725"/>
               <GradientEntry color="#FFCC00" ratio="0.666666666666667"/>
               <GradientEntry color="#FFFFFF" ratio="1"/>
          </LinearGradientSwatchItem>
          <LinearGradientSwatchItem>
               <GradientEntry color="#FF0000" ratio="0"/>
               <GradientEntry color="#FFFF00" ratio="0.164705882352941"/>
               <GradientEntry color="#00FF00" ratio="0.364705882352941"/>
               <GradientEntry color="#00FFFF" ratio="0.498039215686275"/>
               <GradientEntry color="#0000FF" ratio="0.666666666666667"/>
               <GradientEntry color="#FF00FF" ratio="0.831372549019608"/>
               <GradientEntry color="#FF0000" ratio="1"/>
          </LinearGradientSwatchItem>
     </swatches>
</swatchList>
"""
    let Document = XmlDocument()
    // swatch items
    Document.LoadXml(SwatchString)
    let group = SwatchGroup(Document.FirstChild)

    // 252 items in total
    // 26 should be blank/black
    Assert.Equal(252, group.Swatches.Count)
    
    let mutable i = 0
    for swItem in group.Swatches do
          if (swItem.Color = [|0uy;0uy;0uy|]) then
               i <- i + 1
    Assert.Equal(26, i)
    
    // Extended items
    Document.LoadXml(ExtendedSwatchString)
    let extendedgroup = ExtendedSwatchGroup(Document.FirstChild)
    
    // 7 in total
    Assert.Equal(7, extendedgroup.Swatches.Count)
    
    Assert.True(true)
