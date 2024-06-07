#version 150

attribute vec3 vPos;
attribute vec3 vColor;
attribute vec2 vUV;

uniform vec2 OFFSET;
uniform mat4x4 uMVP;

out vec3 ourColor;
out vec2 TexCoord;

void main()
{
    gl_Position = uMVP * vec4(vPos, 1.0) + vec4(OFFSET,0,0);
    ourColor = vColor;
    TexCoord = vec2(vUV.x,-vUV.y);
}
