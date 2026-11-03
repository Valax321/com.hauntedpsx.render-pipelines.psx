using System;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
    [CategoryInfo(Name = "HPSXRP Resources")]
    [Serializable, SupportedOnRenderPipeline(typeof(PSXRenderPipelineAsset))]
    public class PSXGlobalPipelineResources : IRenderPipelineResources
    {
        [Serializable]
        public sealed class ShaderResources
        {
            [ResourcePath("Hidden/HauntedPS1/Sky", SearchType.ShaderName)]
            public Shader skyPS;
            
            [ResourcePath("Hidden/HauntedPS1/AccumulationMotionBlur", SearchType.ShaderName)]
            public Shader accumulationMotionBlurPS;
            
            [ResourcePath("Hidden/HauntedPS1/CopyColorRespectFlipY", SearchType.ShaderName)]
            public Shader copyColorRespectFlipYPS;
            
            [ResourcePath("Hidden/HauntedPS1/CRT", SearchType.ShaderName)]
            public Shader crtPS;
            
            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/PostProcessing/Shaders/Compression.compute")]
            public ComputeShader compressionCS;

            [ResourcePath("Hidden/TerrainEngine/Details/PSX/Vertexlit", SearchType.ShaderName)]
            public Shader terrainDetailLitPS;

            [ResourcePath("Hidden/TerrainEngine/Details/PSX/WavingDoublePass", SearchType.ShaderName)]
            public Shader terrainDetailGrassPS;

            [ResourcePath("Hidden/TerrainEngine/Details/PSX/BillboardWavingDoublePass", SearchType.ShaderName)]
            public Shader terrainDetailGrassBillboardPS;
        }

        [Serializable]
        public sealed class TextureResources
        {
            // Pre-baked noise
            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Texture/WhiteNoise1024RGB.png")]
            public Texture2D[] whiteNoise1024RGBTex;

            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Texture/Bayer/BayerL4x4.png")]
            public Texture2D[] framebufferDitherTex;

            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Texture/Bayer/BayerL4x4.png")]
            public Texture2D[] alphaClippingDitherTex;

            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Texture/BlueNoise16/L/LDR_LLL1_{0}.png")]
            public Texture2D[] blueNoise16LTex;
            
            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Texture/BlueNoise16/RGB/LDR_RGB1_{0}.png")]
            public Texture2D[] blueNoise16RGBTex;

            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Texture/SkyboxTextureCubeDefault.exr")]
            public Texture skyboxTextureCubeDefault;
        }

        [Serializable]
        public sealed class MaterialResources
        {
            [ResourcePath("Packages/com.hauntedpsx.render-pipelines.psx/Runtime/RenderPipelineResources/Material/DefaultOpaqueMat.mat")]
            public Material defaultOpaqueMat;
        }
        
        public int version => 0;
        public bool isAvailableInPlayerBuild => true;
        
        public ShaderResources shaders => _shaders;
        public TextureResources textures => _textures;
        public MaterialResources materials => _materials;

        [SerializeField] private ShaderResources _shaders;
        [SerializeField] private TextureResources _textures;
        [SerializeField] private MaterialResources _materials;
    }
}