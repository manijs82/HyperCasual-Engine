using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HyperCasual_Engine
{
    public class CharacterVisuals
    {
        public GameObject VisualsGameObject;
        
        private readonly CharacterCore _characterCore;
        private readonly PlayerVisualsType _type;

        public CharacterVisuals(CharacterCore characterCore, PlayerVisualsType type)
        {
            _characterCore = characterCore;
            _type = type;
            Init();
        }

        private void Init()
        {
            switch (_type)
            {
                case PlayerVisualsType.Cube:
                    CreateCube();
                    break;
                case PlayerVisualsType.Prefab:
                    CreatePrefab();
                    break;
                default: 
                    VisualsGameObject = new GameObject("PlayerVisuals");
                    break;
            }
        }

        private void CreateCube()
        {
            VisualsGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            VisualsGameObject.transform.SetParent(_characterCore.transform);
            VisualsGameObject.transform.localPosition = Vector3.zero;
            Undo.RegisterCreatedObjectUndo(VisualsGameObject, "SetUp Player Visuals");
        }
        
        private void CreatePrefab()
        {
            if (_characterCore.playerModel == null)
            {
                Debug.LogError("There is no reference to any prefab. Assign a prefab to PlayerModel in the player core component");
                return;
            }
            VisualsGameObject = PrefabUtility.InstantiatePrefab(_characterCore.playerModel, _characterCore.transform) as GameObject;
            VisualsGameObject.transform.localPosition = Vector3.zero;
            Undo.RegisterCreatedObjectUndo(VisualsGameObject, "SetUp Player Visuals");
        }
    }
}