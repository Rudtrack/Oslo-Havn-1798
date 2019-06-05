using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PWCommon1;
using CTS.Internal;

namespace CTS
{
    public class DirStructChecker
    {
        private const string PW_FOLDER_NAME = "Procedural Worlds";

        [InitializeOnLoadMethod]
        static void Check()
        {
            string procWorldsPath;
            string path = GetFolderPath(PWApp.CONF.Folder, out procWorldsPath);

            if (string.IsNullOrEmpty(path) == false)
            {
                if (string.IsNullOrEmpty(procWorldsPath) == false)
                {
                    string dialogText = string.Format("{0} {1} is now using Procedural Worlds' improved  folder structure.\n\n" +
                        "Remnants of an older version of this product were found in this project. A clean update is recommended.\n\n" +
                        "To do a clean update, please follow these steps:\n" +
                        " 1. Save/back up any of your data that may be contained inside the {0} folder ({2}).\n" +
                        " 2. Completely remove {0} (from where it was originally installed and also from the Procedural Worlds folder).\n" +
                        " 3. Reimport the new version of {0}.\n\n",
                        PWApp.CONF.Name, PWApp.CONF.Version, PWApp.CONF.Folder);
                    if (EditorUtility.DisplayDialog(PWApp.CONF.Name + " " + PWApp.CONF.Version, dialogText, "Ok", "Don't show this again") == false)
                    {
                        SelfDestruct();
                    }
                    //AssetDatabase.MoveAsset(path, procWorldsPath + "/" + PWApp.CONF.Folder);
                }
                else
                {
                    Debug.LogWarningFormat("[{0}]: Could not find the '{1}' folder.", PWApp.CONF.Name, PW_FOLDER_NAME);
                }
            }

            //AssetUtils.fold
            //PWApp.CONF.Folder;
        }

        /// <summary>
        /// Get the path of the product folder.
        /// </summary>
        /// <param name="appConfig">Appconfig of the product.</param>
        /// <returns></returns>
        private static string GetFolderPath(string folderName, out string procWorldsPath)
        {
            procWorldsPath = null;
            bool prodFolderFound = false;
            string incorrectPath = null;

            foreach (var path in AssetDatabase.GetAllAssetPaths())
            {
                if (path.EndsWith(PW_FOLDER_NAME))
                {
                    procWorldsPath = path;
                }

                if (path.EndsWith(folderName))
                {
                    prodFolderFound = true;

                    // Product not in the new folder structure and needs to be moved.
                    if (path.Contains(PW_FOLDER_NAME) == false)
                    {
                        incorrectPath = path;
                    }
                }
            }

            if (!prodFolderFound)
            {
                Debug.LogWarningFormat("[{0}]: Could not find the '{1}' folder.", PWApp.CONF.Name, folderName);
            }
            return incorrectPath;
        }

        /// <summary>
        /// Removes this script
        /// </summary>
        private static void SelfDestruct()
        {
            foreach (var path in AssetDatabase.GetAllAssetPaths())
            {
                // If found this script under this products folder
                if (path.EndsWith("DirStructChecker.cs") && path.Contains(PWApp.CONF.Folder))
                {
                    //Debug.LogFormat("This'd have removed '{0}'", path);
                    AssetDatabase.DeleteAsset(path);
                }
            }
        }
    }
}
