using Silk.NET.Maths;
using UIKit;
using UIKit.Controls;
using System.Numerics;
using System.Xml;
using LibXfl;
using LynxAnimator.GUI.Controls;

namespace LynxAnimator;

class Program
{
    private const string DocumentString = """
                                          <DOMDocument xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://ns.adobe.com/xfl/2008/" currentTimeline="1" xflVersion="2.0" creatorInfo="Adobe Flash Professional CS5" platform="Windows" versionInfo="Saved by Adobe Flash Windows 11.0 build 485" majorVersion="11" buildNumber="485" nextSceneIdentifier="5" playOptionsPlayLoop="false" playOptionsPlayPages="false" playOptionsPlayFrameActions="false">
                                               <symbols>
                                                    <Include href="author.xml" itemIcon="1" loadImmediate="false"/>
                                                    <Include href="Logo.xml" itemIcon="1" loadImmediate="false"/>
                                                    <Include href="startbutton.xml" itemIcon="1" loadImmediate="false"/>
                                                    <Include href="Symbol 1.xml" itemIcon="0" loadImmediate="false"/>
                                               </symbols>
                                               <timelines>
                                                    <DOMTimeline name="Titlescreen" currentFrame="35">
                                                         <layers>
                                                              <DOMLayer name="Layer 3" color="#FF800A" current="true" isSelected="true" autoNamed="false" animationType="motion object">
                                                                   <frames>
                                                                        <DOMFrame index="0" duration="25" tweenType="motion object" motionTweenRotate="none" motionTweenScale="false" isMotionObject="true" visibleAnimationKeyframes="2097151" keyMode="8195">
                                                                             <motionObjectXML><AnimationCore TimeScale="24000" Version="1" duration="25000"><TimeMap strength="100" type="Quadratic"/><metadata><names><name langID="en_US" value="zoom-in-2D"/></names><Settings orientToPath="0" xformPtXOffsetPct="0.502309" xformPtYOffsetPct="0.496054" xformPtZOffsetPixels="0"/></metadata><PropertyContainer id="headContainer"><PropertyContainer id="Basic_Motion"><Property enabled="1" id="Motion_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Motion_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Rotation_Z" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Transformation"><Property enabled="1" id="Skew_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Skew_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property TimeMapIndex="0" enabled="1" id="Scale_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,5" next="0,5" previous="0,5" roving="0" timevalue="0"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="22000"/></Property><Property TimeMapIndex="0" enabled="1" id="Scale_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,5" next="0,5" previous="0,5" roving="0" timevalue="0"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="22000"/></Property></PropertyContainer><PropertyContainer id="Colors"><PropertyContainer id="Alpha_ColorXform"><Property TimeMapIndex="0" enabled="1" id="Alpha_Amount" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,77" next="0,77" previous="-2168,77" roving="0" timevalue="4000"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="17000"/></Property></PropertyContainer></PropertyContainer><PropertyContainer id="Filters"/></PropertyContainer></AnimationCore></motionObjectXML>
                                                                             <elements>
                                                                                  <DOMSymbolInstance libraryItemName="startbutton" name="" symbolType="graphic" loop="loop">
                                                                                       <matrix>
                                                                                            <Matrix a="0.04998779296875" d="0.04998779296875" tx="253.6" ty="285.95"/>
                                                                                       </matrix>
                                                                                       <transformationPoint>
                                                                                            <Point x="87" y="44"/>
                                                                                       </transformationPoint>
                                                                                       <color>
                                                                                            <Color alphaMultiplier="0"/>
                                                                                       </color>
                                                                                  </DOMSymbolInstance>
                                                                             </elements>
                                                                        </DOMFrame>
                                                                        <DOMFrame index="25" duration="55" tweenType="motion object" motionTweenRotate="none" motionTweenScale="false" isMotionObject="true" visibleAnimationKeyframes="2097151" keyMode="8195">
                                                                             <motionObjectXML><AnimationCore TimeScale="24000" Version="1" duration="55000"><TimeMap strength="0" type="Quadratic"/><metadata><names><name langID="en_US" value="pulse"/></names><Settings orientToPath="0" xformPtXOffsetPct="0.5" xformPtYOffsetPct="0.5" xformPtZOffsetPixels="0"/></metadata><PropertyContainer id="headContainer"><PropertyContainer id="Basic_Motion"><Property enabled="1" id="Motion_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Motion_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Rotation_Z" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Transformation"><Property enabled="1" id="Skew_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Skew_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/><Keyframe anchor="0,123.016" next="0,123.016" previous="0,123.016" roving="0" timevalue="9000"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="20000"/><Keyframe anchor="0,120.59" next="0,120.59" previous="0,120.59" roving="0" timevalue="34000"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="45000"/></Property><Property enabled="1" id="Scale_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/><Keyframe anchor="0,123.016" next="0,123.016" previous="0,123.016" roving="0" timevalue="9000"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="20000"/><Keyframe anchor="0,120.59" next="0,120.59" previous="0,120.59" roving="0" timevalue="34000"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="45000"/></Property></PropertyContainer><PropertyContainer id="Colors"/><PropertyContainer id="Filters"/></PropertyContainer></AnimationCore></motionObjectXML>
                                                                             <elements>
                                                                                  <DOMSymbolInstance libraryItemName="Symbol 1" name="Start" symbolType="button">
                                                                                       <matrix>
                                                                                            <Matrix tx="170.95" ty="244.15"/>
                                                                                       </matrix>
                                                                                       <transformationPoint>
                                                                                            <Point x="86.6" y="44.35"/>
                                                                                       </transformationPoint>
                                                                                       <Actionscript>
                                                                                            <script><![CDATA[on(press) {
                                          	gotoAndStop("Snail Select", 0);
                                          }]]></script>
                                                                                       </Actionscript>
                                                                                  </DOMSymbolInstance>
                                                                             </elements>
                                                                        </DOMFrame>
                                                                   </frames>
                                                              </DOMLayer>
                                                              <DOMLayer name="Layer 2" color="#9933CC" animationType="motion object">
                                                                   <frames>
                                                                        <DOMFrame index="0" duration="24" tweenType="motion object" motionTweenRotate="none" motionTweenScale="false" isMotionObject="true" visibleAnimationKeyframes="2097151" keyMode="8195">
                                                                             <motionObjectXML><AnimationCore TimeScale="24000" Version="1" duration="24000"><TimeMap strength="0" type="Quadratic"/><TimeMap strength="100" type="Cubic"/><metadata><names><name langID="en_US" value="fly-in-left"/></names><Settings orientToPath="0" xformPtXOffsetPct="0.499581" xformPtYOffsetPct="0.499345" xformPtZOffsetPixels="0"/></metadata><PropertyContainer id="headContainer"><PropertyContainer id="Basic_Motion"><Property TimeMapIndex="1" enabled="1" id="Motion_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,307" next="0,307" previous="0,307" roving="0" timevalue="23000"/></Property><Property TimeMapIndex="1" enabled="1" id="Motion_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="23000"/></Property><Property enabled="1" id="Rotation_Z" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Transformation"><Property enabled="1" id="Skew_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Skew_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Colors"><PropertyContainer id="Alpha_ColorXform"><Property enabled="1" id="Alpha_Amount" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="23000"/></Property></PropertyContainer></PropertyContainer><PropertyContainer id="Filters"/></PropertyContainer></AnimationCore></motionObjectXML>
                                                                             <elements>
                                                                                  <DOMSymbolInstance libraryItemName="author" name="" symbolType="graphic" loop="loop">
                                                                                       <matrix>
                                                                                            <Matrix tx="-270.45" ty="358.35"/>
                                                                                       </matrix>
                                                                                       <transformationPoint>
                                                                                            <Point x="89.35" y="19.05"/>
                                                                                       </transformationPoint>
                                                                                       <color>
                                                                                            <Color alphaMultiplier="0"/>
                                                                                       </color>
                                                                                  </DOMSymbolInstance>
                                                                             </elements>
                                                                        </DOMFrame>
                                                                        <DOMFrame index="24" duration="56" tweenType="motion object" motionTweenRotate="none" motionTweenScale="false" isMotionObject="true" visibleAnimationKeyframes="2097151" keyMode="8195">
                                                                             <motionObjectXML><AnimationCore TimeScale="24000" Version="1" duration="56000"><TimeMap strength="0" type="Quadratic"/><TimeMap strength="100" type="Cubic"/><metadata><names><name langID="en_US" value="fly-in-left"/></names><Settings orientToPath="0" xformPtXOffsetPct="0.499581" xformPtYOffsetPct="0.499345" xformPtZOffsetPixels="0"/></metadata><PropertyContainer id="headContainer"><PropertyContainer id="Basic_Motion"><Property TimeMapIndex="1" enabled="1" id="Motion_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property TimeMapIndex="1" enabled="1" id="Motion_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Rotation_Z" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Transformation"><Property enabled="1" id="Skew_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Skew_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Colors"><PropertyContainer id="Alpha_ColorXform"><Property enabled="1" id="Alpha_Amount" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property></PropertyContainer></PropertyContainer><PropertyContainer id="Filters"/></PropertyContainer></AnimationCore></motionObjectXML>
                                                                             <elements>
                                                                                  <DOMSymbolInstance libraryItemName="author" name="" symbolType="graphic" loop="loop">
                                                                                       <matrix>
                                                                                            <Matrix tx="36.55" ty="358.35"/>
                                                                                       </matrix>
                                                                                       <transformationPoint>
                                                                                            <Point x="89.35" y="19.05"/>
                                                                                       </transformationPoint>
                                                                                       <color>
                                                                                            <Color/>
                                                                                       </color>
                                                                                  </DOMSymbolInstance>
                                                                             </elements>
                                                                        </DOMFrame>
                                                                   </frames>
                                                              </DOMLayer>
                                                              <DOMLayer name="Layer 6" color="#808080" autoNamed="false">
                                                                   <frames>
                                                                        <DOMFrame index="0" duration="79" keyMode="9728">
                                                                             <elements/>
                                                                        </DOMFrame>
                                                                        <DOMFrame index="79" keyMode="9728">
                                                                             <Actionscript>
                                                                                  <script><![CDATA[gotoAndPlay(26);]]></script>
                                                                             </Actionscript>
                                                                             <elements/>
                                                                        </DOMFrame>
                                                                   </frames>
                                                              </DOMLayer>
                                                              <DOMLayer name="Layer 1" color="#4FFF4F" animationType="motion object">
                                                                   <frames>
                                                                        <DOMFrame index="0" duration="24" tweenType="motion object" motionTweenRotate="none" motionTweenScale="false" isMotionObject="true" visibleAnimationKeyframes="2097151" keyMode="8195">
                                                                             <motionObjectXML><AnimationCore TimeScale="24000" Version="1" duration="24000"><TimeMap strength="0" type="Quadratic"/><TimeMap strength="100" type="Cubic"/><metadata><names><name langID="en_US" value="fly-in-top"/></names><Settings orientToPath="0" xformPtXOffsetPct="0.49971" xformPtYOffsetPct="0.499643" xformPtZOffsetPixels="0"/></metadata><PropertyContainer id="headContainer"><PropertyContainer id="Basic_Motion"><Property TimeMapIndex="1" enabled="1" id="Motion_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,1" next="0,1" previous="0,1" roving="0" timevalue="23000"/></Property><Property TimeMapIndex="1" enabled="1" id="Motion_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,233" next="0,233" previous="0,233" roving="0" timevalue="23000"/></Property><Property enabled="1" id="Rotation_Z" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Transformation"><Property enabled="1" id="Skew_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Skew_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Colors"><PropertyContainer id="Alpha_ColorXform"><Property enabled="1" id="Alpha_Amount" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="23000"/></Property></PropertyContainer></PropertyContainer><PropertyContainer id="Filters"/></PropertyContainer></AnimationCore></motionObjectXML>
                                                                             <elements>
                                                                                  <DOMSymbolInstance libraryItemName="Logo" name="" symbolType="graphic" loop="loop">
                                                                                       <matrix>
                                                                                            <Matrix tx="60.05" ty="-216.4"/>
                                                                                       </matrix>
                                                                                       <transformationPoint>
                                                                                            <Point x="215.3" y="105.1"/>
                                                                                       </transformationPoint>
                                                                                       <color>
                                                                                            <Color alphaMultiplier="0"/>
                                                                                       </color>
                                                                                  </DOMSymbolInstance>
                                                                             </elements>
                                                                        </DOMFrame>
                                                                        <DOMFrame index="24" duration="56" tweenType="motion object" motionTweenRotate="none" motionTweenScale="false" isMotionObject="true" visibleAnimationKeyframes="2097151" keyMode="8195">
                                                                             <motionObjectXML><AnimationCore TimeScale="24000" Version="1" duration="56000"><TimeMap strength="0" type="Quadratic"/><TimeMap strength="100" type="Cubic"/><metadata><names><name langID="en_US" value="fly-in-top"/></names><Settings orientToPath="0" xformPtXOffsetPct="0.49971" xformPtYOffsetPct="0.499643" xformPtZOffsetPixels="0"/></metadata><PropertyContainer id="headContainer"><PropertyContainer id="Basic_Motion"><Property TimeMapIndex="1" enabled="1" id="Motion_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property TimeMapIndex="1" enabled="1" id="Motion_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Rotation_Z" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Transformation"><Property enabled="1" id="Skew_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Skew_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,0" next="0,0" previous="0,0" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_X" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property><Property enabled="1" id="Scale_Y" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property></PropertyContainer><PropertyContainer id="Colors"><PropertyContainer id="Alpha_ColorXform"><Property enabled="1" id="Alpha_Amount" ignoreTimeMap="0" readonly="0" visible="1"><Keyframe anchor="0,100" next="0,100" previous="0,100" roving="0" timevalue="0"/></Property></PropertyContainer></PropertyContainer><PropertyContainer id="Filters"/></PropertyContainer></AnimationCore></motionObjectXML>
                                                                             <elements>
                                                                                  <DOMSymbolInstance libraryItemName="Logo" name="" symbolType="graphic" loop="loop">
                                                                                       <matrix>
                                                                                            <Matrix tx="61.05" ty="16.6"/>
                                                                                       </matrix>
                                                                                       <transformationPoint>
                                                                                            <Point x="215.3" y="105.1"/>
                                                                                       </transformationPoint>
                                                                                       <color>
                                                                                            <Color/>
                                                                                       </color>
                                                                                  </DOMSymbolInstance>
                                                                             </elements>
                                                                        </DOMFrame>
                                                                   </frames>
                                                              </DOMLayer>
                                                         </layers>
                                                    </DOMTimeline>
                                               </timelines>
                                               <timelines>
                                                    <DOMTimeline name="Snail Select">
                                                         <layers>
                                                              <DOMLayer name="Layer 1" color="#4FFF4F" current="true" isSelected="true">
                                                                   <frames>
                                                                        <DOMFrame index="0" duration="2" keyMode="9728">
                                                                             <elements/>
                                                                        </DOMFrame>
                                                                   </frames>
                                                              </DOMLayer>
                                                         </layers>
                                                    </DOMTimeline>
                                               </timelines>
                                               <swatchLists>
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
                                               </swatchLists>
                                               <extendedSwatchLists>
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
                                               </extendedSwatchLists>
                                               <PrinterSettings/>
                                               <publishHistory>
                                                    <PublishItem publishSize="5998" publishTime="1672957613" publishDebug="true"/>
                                                    <PublishItem publishSize="5986" publishTime="1672957200" publishDebug="true"/>
                                                    <PublishItem publishSize="5985" publishTime="1672957145" publishDebug="true"/>
                                                    <PublishItem publishSize="5980" publishTime="1672956973" publishDebug="true"/>
                                               </publishHistory>
                                          </DOMDocument>
                                          """;

    static void Main(string[] args)
    {
        UIKitApplication.Init();

        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(DocumentString);
        var document = new DomDocument(xmlDoc.FirstChild);

        using var mainWindow = new Window(
            "Lynx Animator",
            new Vector2D<int>(1280, 720),
            new Vector2D<int>(20, 20)
        );
        mainWindow.CentralLayout = new AbsoluteLayout(null);

        var grid = new GridLayout(mainWindow.CentralLayout)
        {
            Position = new Vector2(300, 130),
            Size = new Vector2(340, 200),
            Separation = 3.0f
        };

        // add swatch buttons
        foreach (var swatch in document.SwatchGroups[0].Swatches)
        {
            new SolidSwatchGroupItem(grid)
            {
                SwatchItem = swatch,
                Size = new Vector2(16, 16),
            };
        }

        var field = new InputField(mainWindow.CentralLayout)
        {
            Placeholder = "type here :3",
            Position = new Vector2(100, 180),
            Size = new Vector2(244, 36),
        };
        
        var button = new Button(mainWindow.CentralLayout)
        {
            Text = "Say Hello",
            Position = new Vector2(100, 130),
            Size = new Vector2(100, 30),
        };
        button.OnPressed += (sender, eventArgs) =>
        {
            // shut up rider, this button is gone when the window is disposed anyways
            new Label(mainWindow.CentralLayout)
            {
                Text = "Hello UIKit!\nThis is a multiline text!",
                Position = new Vector2(20, 20),
                Size = new Vector2(200, 200),
            };
        };

        UIKitApplication.Run();
    }
}
