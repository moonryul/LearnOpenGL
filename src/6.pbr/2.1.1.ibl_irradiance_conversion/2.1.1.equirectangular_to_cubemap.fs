//MJ: From Equirectangular to Cubemap

#version 330 core
out vec4 FragColor;
 // MJ: FragColor refers to the render target defined by   glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, GL_TEXTURE_CUBE_MAP_POSITIVE_X + i, envCubemap, 0);
 
in vec3 WorldPos;

uniform sampler2D equirectangularMap;
// MJ: cf. equirectangularToCubemapShader.setInt("equirectangularMap", 0); 
// glActiveTexture(GL_TEXTURE0); in the application code

const vec2 invAtan = vec2(0.1591, 0.3183);
//MJ:  (spherical to cartesian)
vec2 SampleSphericalMap(vec3 v)
{
    vec2 uv = vec2(atan(v.z, v.x), asin(v.y));
    uv *= invAtan;
    uv += 0.5;
    return uv;
}

void main()
{		
    vec2 uv = SampleSphericalMap(normalize(WorldPos));
    vec3 color = texture(equirectangularMap, uv).rgb;
    
    FragColor = vec4(color, 1.0);
}
