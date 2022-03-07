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
        private CharacterCore _target;
        
        private ReflectedTypes<Ability> _abilityTypes;
        
        private string[] _currentAbilitiesNames;
        private int _removeAbilityIndex;
        
        private void OnEnable()
        {
            _target = target as CharacterCore;
            _abilityTypes = new ReflectedTypes<Ability>();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Setup Visuals")) _target.CreatePlayerVisuals();
                if (GUILayout.Button("Remove Visuals")) _target.RemovePlayerVisuals();
            }
            
            EditorGUILayout.Separator();

            DrawAddAbility();

            if (_target.abilities != null) 
                DrawRemoveAbility();

            EditorGUILayout.Separator();
            
            if (GUILayout.Button("Clear Player")) 
                ClearPlayer();

            EditorGUILayout.Separator();
            
            DrawCharacterState();
        }

        private void DrawCharacterState()
        {
            GUI.enabled = false;
            EditorGUILayout.EnumPopup("Current State", _target.CurrentState);
            GUI.enabled = true;
        }

        private void DrawRemoveAbility()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                _currentAbilitiesNames = new string[_target.abilities.Count];

                if (_currentAbilitiesNames.Length > 0)
                {
                    for (var i = 0; i < _currentAbilitiesNames.Length; i++)
                        _currentAbilitiesNames[i] = ObjectNames.NicifyVariableName(_target.abilities[i].GetType().Name);
                    if (GUILayout.Button("Remove Ability"))
                        _target.RemoveAndDestroyAbilityWithUndo(_target.abilities[_removeAbilityIndex]);
                    EditorGUILayout.LabelField("Ability Type", GUILayout.Width(80));
                    _removeAbilityIndex = EditorGUILayout.Popup(_removeAbilityIndex, _currentAbilitiesNames);
                }
            }
        }

        private void DrawAddAbility()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Add Ability"))
                    _target.CreateAndAddAbilityWithUndo(_abilityTypes.Types[_abilityTypes.TypeChoiceIndex]);
                EditorGUILayout.LabelField("Ability Type", GUILayout.Width(80));
                _abilityTypes.TypeChoiceIndex =
                    EditorGUILayout.Popup(_abilityTypes.TypeChoiceIndex, _abilityTypes.TypesNames);
            }
        }

        private void ClearPlayer()
        {
            _target.abilities.Clear();
            foreach (var component in _target.gameObject.GetComponents(typeof(Component)))
            {
                if (component is Ability)
                    DestroyImmediate(component);
            }

            for (int i = _target.transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(_target.transform.GetChild(i).gameObject);
            }
        }
    }
}