using System;
using HyperCasual_Engine.Abilities;
using HyperCasual_Engine.Utils;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(CharacterCore))]
    public class PlayerCoreEditor : UnityEditor.Editor
    {
        private ReflectedTypes<MovementAbility> _movementTypes;
        
        private void OnEnable()
        {
            _movementTypes = new ReflectedTypes<MovementAbility>();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var t = target as CharacterCore;
            if(t == null) return;
            
            _movementTypes.TypeChoiceIndex = EditorGUILayout.Popup("Movement Type", _movementTypes.TypeChoiceIndex, _movementTypes.TypesNames);
            
            EditorGUILayout.Separator();

            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Add Movement")) RegisterPlayerMovement(t);

            if (GUILayout.Button("Setup Visuals")) RegisterPlayerVisuals(t);

            EditorGUILayout.EndHorizontal();
            
            if (GUILayout.Button("Remove Components"))
            {
                t.abilities.Clear();
                foreach (var component in t.gameObject.GetComponents(typeof(Component)))
                {
                    if(component is Ability)
                        DestroyImmediate(component);
                }

                for (int i = t.transform.childCount - 1; i >= 0; i--)
                {
                    DestroyImmediate(t.transform.GetChild(i).gameObject);
                }
            }
        }

        private void RegisterPlayerVisuals(CharacterCore core) => 
            core.CreatePlayerVisuals();

        private void RegisterPlayerMovement(CharacterCore core)
        {
            var moveComponent = Undo.AddComponent(core.gameObject, _movementTypes.Types[_movementTypes.TypeChoiceIndex]);
            core.AddAbility(moveComponent as MovementAbility);
        }
    }
}