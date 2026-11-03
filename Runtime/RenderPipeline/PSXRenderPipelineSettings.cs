using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
    [DisplayInfo(name = "PSX")]
    [SupportedOnRenderPipeline(typeof(PSXRenderPipelineAsset))]
    public class PSXRenderPipelineSettings : RenderPipelineGlobalSettings<PSXRenderPipelineSettings, PSXRenderPipeline>
    {
        [SerializeField] private RenderPipelineGraphicsSettingsContainer settings = new();
        protected override List<IRenderPipelineGraphicsSettings> settingsList => settings.settingsList;

        private static string GetDefaultPath() => $"Assets/Settings/{nameof(PSXRenderPipeline)}GlobalSettings.asset";

        public static PSXRenderPipelineSettings Ensure(bool canCreateNewAsset = true)
        {
#if UNITY_EDITOR
            var currentInstance =
                GraphicsSettings.GetSettingsForRenderPipeline<PSXRenderPipeline>() as PSXRenderPipelineSettings;
            if (RenderPipelineGlobalSettingsUtils.TryEnsure<PSXRenderPipelineSettings, PSXRenderPipeline>(
                    ref currentInstance, GetDefaultPath(),
                    canCreateNewAsset))
            {
                if (currentInstance)
                {
                    // Upgrade here if necessary
                }
                
                return currentInstance;
            }

#endif
            return null;
        }
    }
}