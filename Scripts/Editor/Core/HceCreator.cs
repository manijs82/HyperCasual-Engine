using System;
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
            CreateObject(typeof(LevelCreator), "LevelCreator");
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
            CreateObject(typeof(InputManager), "InputManager");
        }
        
        [MenuItem("GameObject/HCE/Managers/LevelManager", false, 10)]
        static void CreateLevelManager(MenuCommand menuCommand)
        {
            CreateObject(typeof(LevelManager), "LevelManager");
        }
        
        [MenuItem("GameObject/HCE/Managers/GameManager", false, 10)]
        static void CreateGameManager(MenuCommand menuCommand)
        {
            CreateObject(typeof(GameManager), "GameManager");
        }
        
        [MenuItem("GameObject/HCE/Managers/ScoreManager", false, 10)]
        static void CreateScoreManager(MenuCommand menuCommand)
        {
            CreateObject(typeof(ScoreManager), "ScoreManager");
        }

        static void CreateObject(Type type, string name)
        {
            GameObject go = new GameObject(name);
            go.transform.position = Vector3.zero;
            go.AddComponent(type);
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
