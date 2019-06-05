using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CTSSetup : MonoBehaviour
{
    public static void UpdatePipelineDefines()
    {
#if UNITY_EDITOR
        string originalBuildSettings = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        string currBuildSettings = originalBuildSettings;

        if (Shader.Find("HDRP/Lit"))
        {
            if (!currBuildSettings.Contains("HDPipeline"))
            {
                if (string.IsNullOrEmpty(currBuildSettings))
                {
                    currBuildSettings = "HDPipeline";
                }
                else
                {
                    currBuildSettings += ";HDPipeline";
                }
            }
        }
        else
        {
            currBuildSettings = currBuildSettings.Replace("HDPipeline;", "");
            currBuildSettings = currBuildSettings.Replace("HDPipeline", "");
        }
        if (originalBuildSettings != currBuildSettings)
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, currBuildSettings);
        }
#endif
    }
}
