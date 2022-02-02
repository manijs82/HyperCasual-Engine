using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class MagicButtonsTab : HceWindowTab
    {
        private bool _showWarnings = true;
        private string _newParentName = "parent";

        public override void OnEnable()
        {
            _showWarnings = EditorPrefs.GetBool("MAGIC_BUTTONS_showWarnings", true);
            _newParentName = EditorPrefs.GetString("MAGIC_BUTTONS_parentName", "parent");
        }

        public override void DrawTab()
        {
            _showWarnings = EditorGUILayout.Toggle("Show Warnings", _showWarnings);
            if(_showWarnings)
                EditorGUILayout.HelpBox("This buttons deletes all game objects and sets up a new level", MessageType.Warning);
            if (GUILayout.Button("Setup New Level Scene")) MagicButtons.SetUpLevel();
            if(_showWarnings)        
                EditorGUILayout.HelpBox("This buttons deletes all game objects and sets up a new main menu", MessageType.Warning);
            if (GUILayout.Button("Setup New Menu Scene")) MagicButtons.SetUpMainMenu();
            if (GUILayout.Button("Clear Player Prefs")) MagicButtons.ClearPlayerPrefs();
            if (GUILayout.Button("Clear Persistent Data Path")) MagicButtons.ClearPersistentDataPath();
            if (GUILayout.Button("Open Persistent Data Path")) MagicButtons.OpenPersistentDataPath();
            EditorGUILayout.Space();
            if (GUILayout.Button("Set new parent for selected transforms")) MagicButtons.ParentSelectedObject(_newParentName);
            _newParentName = EditorGUILayout.TextField("New parent name", _newParentName);
            EditorGUILayout.Space();
        }

        public override void OnDisable()
        {
            EditorPrefs.SetBool("MAGIC_BUTTONS_showWarnings", _showWarnings);
            EditorPrefs.SetString("MAGIC_BUTTONS_parentName", _newParentName);
        }
    }
}