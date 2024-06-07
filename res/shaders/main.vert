#version 150

attribute vec3 vPos;
attribute vec3 vColor;
attribute vec2 vUV;

out vec3 ourColor;
out vec2 TexCoord;

void main()
{
    gl_Position = vec4(vPos, 1.0);
    ourColor = vColor;
    TexCoord = vUV;
}
