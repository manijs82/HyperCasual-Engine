using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class MagicButtonsTab : HceWindowTab
    {
        private bool _showWarnings = true;

        public override void OnEnable()
        {
            _showWarnings = EditorPrefs.GetBool("MAGIC_BUTTONS_showWarnings", true);
        }

        public override void DrawTab()
        {
            _showWarnings = EditorGUILayout.Toggle("Show Warnings", _showWarnings);
            if(_showWarnings)
                EditorGUILayout.HelpBox("This buttons deletes all game objects and sets up a new level", MessageType.Warning);
            if (GUILayout.Button("Setup New Level Scene"))
            {
                MagicButtons.SetUpLevel();
            }
            if(_showWarnings)        
                EditorGUILayout.HelpBox("This buttons deletes all game objects and sets up a new main menu", MessageType.Warning);
            if (GUILayout.Button("Setup New Menu Scene"))
            {
                MagicButtons.SetUpMainMenu();
            }           
        }

        public override void OnDisable()
        {
            EditorPrefs.SetBool("MAGIC_BUTTONS_showWarnings", _showWarnings);
        }
    }
}