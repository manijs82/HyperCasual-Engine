using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class MagicButtonsTab : HceWindowTab
    {
        public override void DrawTab()
        {
            EditorGUILayout.HelpBox("This buttons deletes all game objects and sets up a new scene", MessageType.Warning);
            if (GUILayout.Button("SetUp New Scene"))
            {
                MagicButtons.SetUpScene();
            }
                        
                        
        }

        public override void Init() { }
    }
}