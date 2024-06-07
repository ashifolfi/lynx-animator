#version 150

attribute vec3 vPos;
attribute vec3 vColor;
attribute vec2 vUV;

uniform mat4 uMVP;

out vec3 ourColor;
out vec2 TexCoord;

void main()
{
    vec4 position = uMVP * vec4(vPos, 1.0);
    gl_Position = position;
    ourColor = vColor;
    TexCoord = vUV;
}
