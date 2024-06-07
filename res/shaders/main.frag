#version 150
//uniform sampler2D uMeshTexture;

in vec3 ourColor;
in vec2 TexCoord;

void main() {
    gl_FragColor = vec4(ourColor, 1.0);// * texture2D(uMeshTexture, TexCoord);
}
