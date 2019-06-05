using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CTS
{
    [InitializeOnLoad]
    public class CTSSetupEditor : Editor
    {
        static CTSSetupEditor()
        {
            EditorApplication.update += CTSSetup.UpdatePipelineDefines;
            CTSSetup.UpdatePipelineDefines();

            int majorVersion, minorVersion, patchVersion = 0;
            bool parseFailed = false;

            if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MajorVersion, out majorVersion))
            {
                parseFailed = true;
                Debug.LogWarning("Error when reading the CTS major version number!");
            }
            if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MinorVersion, out minorVersion))
            {
                parseFailed = true;
                Debug.LogWarning("Error when reading the CTS minor version number!");
            }
            if (!Int32.TryParse(CTS.Internal.PWApp.CONF.PatchVersion, out patchVersion))
            {
                parseFailed = true;
                Debug.LogWarning("Error when reading the CTS patch version number!");
            }

            if (!parseFailed)
            {
                if (majorVersion != CTSConstants.MajorVersion ||
                   minorVersion != CTSConstants.MinorVersion ||
                   patchVersion != CTSConstants.PatchVersion)
                {
                    Debug.LogError("Version Mismatch between app config and CTS constants!");
                }

            }
        }
    }
}
