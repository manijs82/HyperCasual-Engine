using HyperCasual_Engine.Abilities;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AbilityScriptableObjectData), true)]
    public class AbilityScriptableObjectDataEditor : UnityEditor.Editor
    {
        private bool _drawAllProperties;
        
        private AbilityScriptableObjectData _target;
        
        private SerializedObject _so;
        private SerializedProperty _active;
        private SerializedProperty _scriptableObject;
        private SerializedProperty _useScriptableObjectData;

        private void OnEnable()
        {
            _target = target as AbilityScriptableObjectData;
            
            _so = serializedObject;
            _active = _so.FindProperty("active");
            _scriptableObject = _so.FindProperty("scriptableObject");
            _useScriptableObjectData = _so.FindProperty("useScriptableObjectData");
        }

        public override void OnInspectorGUI()
        {
            if(_drawAllProperties)
            {
                DrawProperties();
            }

            if (!_drawAllProperties)
            {
                base.OnInspectorGUI();
            }
            _drawAllProperties = _target.useScriptableObjectData;
        }

        private void DrawProperties()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((Ability) target), target.GetType(), false);
            GUI.enabled = true;

            _so.Update();
            
            EditorGUILayout.PropertyField(_active);
            EditorGUILayout.PropertyField(_useScriptableObjectData);
            EditorGUILayout.PropertyField(_scriptableObject);

            _so.ApplyModifiedProperties();
        }
    }
}