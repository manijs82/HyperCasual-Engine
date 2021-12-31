using HyperCasual_Engine.LevelCreation;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class HceCreator : UnityEditor.Editor
    {
        [MenuItem("GameObject/HCE/LevelEditor", false, 10)]
        static void CreateLevelEditor(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("LevelEditor");
            go.transform.position = Vector3.zero;
            go.AddComponent<LevelEditorObject>();
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
        
        [MenuItem("GameObject/HCE/Player/Empty", false, 10)]
        static void SetUpPlayer(MenuCommand menuCommand)
        {
            GameObject go = CreatePlayer();
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
        
        [MenuItem("GameObject/HCE/Managers/InputManager", false, 10)]
        static void CreateInputManager(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("InputManager");
            go.transform.position = Vector3.zero;
            go.AddComponent<InputManager>();
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
        
        [MenuItem("GameObject/HCE/Managers/LevelManager", false, 10)]
        static void CreateLevelManager(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("LevelManager");
            go.transform.position = Vector3.zero;
            go.AddComponent<LevelManager>();
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        private static GameObject CreatePlayer()
        {
            GameObject go = new GameObject("Player");
            go.AddComponent<CharacterCore>();
            
            return go;
        }
    }
}
