
//MJ: //MJ: From Equirectangular to Cubemap
#version 330 core
layout (location = 0) in vec3 aPos;
// MJ: This line  specifies the location of the input attribute variable aPos within **the vertex data** provided by the application.
// The vertex data =  the vertex array object (VAO) and its associated vertex buffer object (VBO) 

out vec3 WorldPos;

uniform mat4 projection;
uniform mat4 view;

void main()
{
    WorldPos = aPos;
    gl_Position =  projection * view * vec4(WorldPos, 1.0);
}