using System;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
#if UNITY_6000_7_OR_NEWER
    [AutoStaticsCleanup]
#endif
    [Serializable, VolumeComponentMenu("HauntedPS1/AccumulationMotionBlurVolume")]
    public partial class AccumulationMotionBlurVolume : VolumeComponent
    {
        public ClampedFloatParameter weight = new ClampedFloatParameter(0.0f, 0.0f, 1.0f);
        public ClampedFloatParameter vignette = new ClampedFloatParameter(0.0f, -1.0f, 1.0f);
        public ClampedFloatParameter dither = new ClampedFloatParameter(1.0f, 0.0f, 1.0f);
        public ClampedFloatParameter zoom = new ClampedFloatParameter(0.0f, -1.0f, 1.0f);
        public ClampedFloatParameter zoomDither = new ClampedFloatParameter(0.0f, 0.0f, 1.0f);
        public ClampedFloatParameter anisotropy = new ClampedFloatParameter(0.0f, -1.0f, 1.0f);
        public BoolParameter applyToUIOverlay = new BoolParameter(false);

        static AccumulationMotionBlurVolume s_Default = null;
        public static AccumulationMotionBlurVolume @default
        {
            get
            {
                if (s_Default == null)
                {
                    s_Default = ScriptableObject.CreateInstance<AccumulationMotionBlurVolume>();
                    s_Default.hideFlags = HideFlags.HideAndDontSave;
                }
                return s_Default;
            }
        }
    }
}