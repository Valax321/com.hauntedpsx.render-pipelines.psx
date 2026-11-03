using System;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
#if UNITY_6000_7_OR_NEWER
    [AutoStaticsCleanup]
#endif
    [Serializable, VolumeComponentMenu("HauntedPS1/LightingVolume")]
    public partial class LightingVolume : VolumeComponent
    {
        [Serializable]
        public enum LightingClampMode
        {
            None = 0,
            Clamp,
            SoftClamp
        };

        [Serializable]
        public sealed class LightingClampModeParameter : VolumeParameter<LightingClampMode>
        {
            public LightingClampModeParameter(LightingClampMode value, bool overrideState = false)
                : base(value, overrideState) { }
        }

        public BoolParameter lightingIsEnabled = new BoolParameter(false);
        public MinFloatParameter bakedLightingMultiplier = new MinFloatParameter(1.0f, 0.0f);
        public MinFloatParameter vertexColorLightingMultiplier = new MinFloatParameter(0.0f, 0.0f);
        public MinFloatParameter dynamicLightingMultiplier = new MinFloatParameter(1.0f, 0.0f);
        public ClampedIntParameter dynamicLightsMaxCount = new ClampedIntParameter(256, 1, 256);
        public ClampedIntParameter dynamicLightsMaxPerObjectCount = new ClampedIntParameter(4, 1, 8);
        public LightingClampModeParameter lightingClampMode = new LightingClampModeParameter(LightingClampMode.None);
        public MinFloatParameter lightingClamp = new MinFloatParameter(1.0f, 0.0f);
        public ClampedFloatParameter lightingClampSharpness = new ClampedFloatParameter(0.0f, 0.0f, 1.0f);

        static LightingVolume s_Default = null;
        public static LightingVolume @default
        {
            get
            {
                if (s_Default == null)
                {
                    s_Default = ScriptableObject.CreateInstance<LightingVolume>();
                    s_Default.hideFlags = HideFlags.HideAndDontSave;
                }
                return s_Default;
            }
        }
    }
}