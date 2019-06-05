// Copyright © 2018 Procedural Worlds Pty Limited.  All Rights Reserved.
using UnityEditor;
using PWCommon1;

namespace CTS.Internal
{
    [InitializeOnLoad]
    public static class PWApp
    {
        private const string CONF_NAME = "CTS";

        public static readonly AppConfig CONF;

        static PWApp()
        {
            CONF = AssetUtils.GetConfig(CONF_NAME);			
            if(CONF != null)
            {
                Prod.Checkin(CONF);
            }
        }

        //Commented out below for now to prevent users running into issues when installing over an older CTS version

        ///// <summary>
        ///// Get an editor utils object that can be used for common Editor stuff - DO make sure to Dispose() the instance.
        ///// </summary>
        ///// <param name="editorObj">The class that uses the utils. Just pass in "this".</param>
        ///// <param name="customUpdateMethod">(Optional) The method to be called when the GUI needs to be updated. (Repaint will always be called.)</param>
        ///// <returns>Editor Utils</returns>
        //public static EditorUtils GetEditorUtils(IPWEditor editorObj, System.Action customUpdateMethod = null)
        //{
        //    return new EditorUtils(CONF, editorObj, customUpdateMethod);
        //}
    }
}
