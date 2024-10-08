#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.Tools.Editor
{
    public class CustomEditorConsole : EditorWindow
    {
        private Vector2 scrollPosition;
    
        [MenuItem("thief01/Windows/Custom Console")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(CustomEditorConsole));
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Button("Show Errors");
            GUILayout.Button("Show Logs");
            GUILayout.Button("Show Warnings");
        
            EditorGUILayout.EndHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, true);
        

            var messages = Diagnostics.GetLogsWithTag();
            var msg = "";
        
            for (int i = 0; i < messages.Count; i++)
            {
                msg += messages[i].Message + "\n";
            }
            EditorGUILayout.TextArea(msg );
        
        
            EditorGUILayout.EndScrollView();
        }
    }
}

#endif