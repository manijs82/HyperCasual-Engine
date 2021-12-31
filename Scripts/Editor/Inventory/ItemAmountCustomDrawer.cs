using HyperCasual_Engine.Inventory;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomPropertyDrawer(typeof(ItemAmount))]
    public class ItemAmountCustomDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            var countRect = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
            var nameRect = new Rect(position.width / 2 + 80, position.y, position.width, EditorGUIUtility.singleLineHeight);

            var itemCountProperty = property.FindPropertyRelative("count");
            var itemNameProperty = property.FindPropertyRelative("definition").FindPropertyRelative("itemName");
            
            EditorGUI.PropertyField(countRect, itemCountProperty, new GUIContent("Count"));
            EditorGUI.LabelField(nameRect, itemNameProperty.stringValue, EditorStyles.boldLabel);

            EditorGUI.indentLevel = indent;
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}