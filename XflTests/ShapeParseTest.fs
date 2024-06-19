module XflTests.ShapeParseTest

open System.Xml
open Xunit
open LibXfl
open System.Numerics

[<Fact>]
let ShapeParseTest () =
    let ShapeString = """
    <DOMShape xmlns:xsi="https://www.w3.org/2001/XMLSchema-instance" xmlns="https://ns.adobe.com/xfl/2008/">
      <strokes>
        <StrokeStyle index="1">
          <SolidStroke scaleMode="normal">
            <fill>
              <SolidColor/>
            </fill>
          </SolidStroke>
        </StrokeStyle>
      </strokes>
      <edges>
        <Edge strokeStyle="1" edges="!0 203S4[0 119 59 59!59 59[119 0 203 0!203 0[287 0 346 59!346 59[406 119 406 203!406 203[406 287 346 346!346 346[287 406 203 406!203 406[119 406 59 346!59 346[0 287 0 203"/>
        <!-- These should be skipped over -->
        <Edge cubics="!346 59(;386,99 406,147 406,203q346 59Q406 119q406 203);"/>
        <Edge cubics="!203 0(;259,0 307,20 346,59q203 0Q287 0q346 59);"/>
        <Edge cubics="!59 59(;99,20 147,0 203,0q59 59Q119 0q203 0);"/>
        <Edge cubics="!203 406(;147,406 99,386 59,346q203 406Q119 406q59 346);"/>
        <Edge cubics="!346 346(;307,386 259,406 203,406q346 346Q287 406q203 406);"/>
        <Edge cubics="!406 203(;406,259 386,307 346,346q406 203Q406 287q346 346);"/>
        <Edge cubics="!0 203(;0,147 20,99 59,59q0 203Q0 119q59 59)59,59;"/>
        <Edge cubics="!59 346(59,346;20,307 0,259 0,203q59 346Q0 287q0 203);"/>
      </edges>
    </DOMShape>
    """
    
    let ExpectedCommands = [|
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
      DomShape.VectorCommand.CommandType.MoveTo
      DomShape.VectorCommand.CommandType.QuadraticTo
    |]
    
    let ExpectedPoints = [|
      Vector2(0.0f, 203.0f); Vector2(0.0f, 0.0f)
      Vector2(0.0f, 119.0f); Vector2(59.0f, 59.0f)
      Vector2(59.0f, 59.0f); Vector2(0.0f, 0.0f)
      Vector2(119.0f, 0.0f); Vector2(203.0f, 0.0f)
      Vector2(203.0f, 0.0f); Vector2(0.0f, 0.0f)
      Vector2(287.0f, 0.0f); Vector2(346.0f, 59.0f)
      Vector2(346.0f, 59.0f); Vector2(0.0f, 0.0f)
      Vector2(406.0f, 119.0f); Vector2(406.0f, 203.0f)
      Vector2(406.0f, 203.0f); Vector2(0.0f, 0.0f)
      Vector2(406.0f, 287.0f); Vector2(346.0f, 346.0f)
      Vector2(346.0f, 346.0f); Vector2(0.0f, 0.0f)
      Vector2(287.0f, 406.0f); Vector2(203.0f, 406.0f)
      Vector2(203.0f, 406.0f); Vector2(0.0f, 0.0f)
      Vector2(119.0f, 406.0f); Vector2(59.0f, 346.0f)
      Vector2(59.0f, 346.0f); Vector2(0.0f, 0.0f)
      Vector2(0.0f, 287.0f); Vector2(0.0f, 203.0f)
    |]

    let Document = XmlDocument()
    Document.LoadXml(ShapeString)
    // first child should be the DomShape
    let Shape = DomShape(Document.FirstChild)
    
    // we should only get 1 edge out of thatI just 
    Assert.Equal(1, Shape.Edges.Count)
    
    // it should be using stroke style 1
    Assert.Equal(1, Shape.Edges[0].StrokeStyle)
    
    // each edge command should match what we got
    let mutable i = 0
    for edgeCommand in Shape.Edges[0].Commands do
      Assert.Equal(ExpectedCommands[i], edgeCommand.Type)
      Assert.Equal(ExpectedPoints[(i * 2)], edgeCommand.Point1)
      Assert.Equal(ExpectedPoints[(i * 2) + 1], edgeCommand.Point2)
      i <- i + 1