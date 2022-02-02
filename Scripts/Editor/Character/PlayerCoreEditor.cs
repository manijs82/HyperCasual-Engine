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
            _currentAbilitiesNames = new string[_target.abilities.Count];
            for (var i = 0; i < _currentAbilitiesNames.Length; i++)
                _currentAbilitiesNames[i] = ObjectNames.NicifyVariableName(_target.abilities[i].GetType().Name);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Setup Visuals")) RegisterPlayerVisuals(_target);
            
            EditorGUILayout.Separator();

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Add Ability")) RegisterAbility(_target);
                _abilityTypes.TypeChoiceIndex = EditorGUILayout.Popup("Ability Type", _abilityTypes.TypeChoiceIndex, _abilityTypes.TypesNames);
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Remove Ability")) _target.RemoveAndDestroyAbilityWithUndo(_target.abilities[_removeAbilityIndex]);
                _removeAbilityIndex = EditorGUILayout.Popup("Ability Type", _removeAbilityIndex, _currentAbilitiesNames);
            }
            
            EditorGUILayout.Separator();
            
            if (GUILayout.Button("Clear Player"))
            {
                _target.abilities.Clear();
                foreach (var component in _target.gameObject.GetComponents(typeof(Component)))
                {
                    if(component is Ability)
                        DestroyImmediate(component);
                }

                for (int i = _target.transform.childCount - 1; i >= 0; i--)
                {
                    DestroyImmediate(_target.transform.GetChild(i).gameObject);
                }
            }
        }

        private void RegisterPlayerVisuals(CharacterCore core) => 
            core.CreatePlayerVisuals();

        private void RegisterAbility(CharacterCore core) => 
            core.CreateAndAddAbilityWithUndo(_abilityTypes.Types[_abilityTypes.TypeChoiceIndex]);
    }
}