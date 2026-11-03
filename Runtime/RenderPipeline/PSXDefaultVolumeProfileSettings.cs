using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
    [Serializable]
    [SupportedOnRenderPipeline(typeof(PSXRenderPipelineAsset))]
    [UnityEngine.Categorization.CategoryInfo(Name = "Default Volume Settings")]
    public class PSXDefaultVolumeProfileSettings : IDefaultVolumeProfileSettings
    {
        [SerializeField] private VolumeProfile profile;
        
        public int version => 0;

        public bool isAvailableInPlayerBuild => true;

        public VolumeProfile volumeProfile
        {
            get => profile;
            set => profile = value;
        }
    }
}