using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using HauntedPSX.RenderPipelines.PSX.Runtime;
using UnityEditor;

namespace HauntedPSX.RenderPipelines.PSX.Editor
{
    [ExecuteInEditMode]
    static class PSXRenderPipelineAssetFactory
    {
    	static readonly string s_PackagePath = "Packages/com.hauntedpsx.render-pipelines.psx/";

#if UNITY_2021_2_OR_NEWER
        [MenuItem("HauntedPS1/Create HauntedPS1 Render Pipeline Asset", priority = CoreUtils.Priorities.assetsCreateRenderingMenuPriority)]
#else
        [MenuItem("HauntedPS1/Create HauntedPS1 Render Pipeline Asset", priority = CoreUtils.assetCreateMenuPriority1)]
#endif
        static void CreatePSXRenderPipelineAsset()
        {
            var icon = EditorGUIUtility.FindTexture("ScriptableObject Icon");
            
#if UNITY_6000_7_OR_NEWER
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(EntityId.None, ScriptableObject.CreateInstance<DoCreateNewAssetPSXRenderPipelineAsset>(), "PSXRenderPipelineAsset.asset", icon, null);
#else
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<DoCreateNewAssetPSXRenderPipelineAsset>(), "PSXRenderPipelineAsset.asset", icon, null);
#endif
        }

        class DoCreateNewAssetPSXRenderPipelineAsset 
#if UNITY_6000_7_OR_NEWER
            : UnityEditor.ProjectWindowCallback.AssetCreationEndAction
#else
            : UnityEditor.ProjectWindowCallback.EndNameEditAction
#endif
        {
#if UNITY_6000_7_OR_NEWER
            public override void Action(EntityId entityId, string pathName, string resourceFile)
#else
            public override void Action(int instanceId, string pathName, string resourceFile)
#endif
            {
                var newAsset = CreateInstance<PSXRenderPipelineAsset>();
                newAsset.name = Path.GetFileName(pathName);

                ResourceReloader.ReloadAllNullIn(newAsset, s_PackagePath);

                AssetDatabase.CreateAsset(newAsset, pathName);
                ProjectWindowUtil.ShowCreatedAsset(newAsset);
            }
        }
    }
}
