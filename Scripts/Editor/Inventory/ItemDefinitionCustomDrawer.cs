using System;
using HyperCasual_Engine.Inventory;
using HyperCasual_Engine.Utils;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomPropertyDrawer(typeof(ItemDefinition))]
    public class ItemDefinitionCustomDrawer : PropertyDrawer
    {
        private const int SpaceBetweenProperties = 20;
        private float[] _attributesHeights;

        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var attributes = property.FindPropertyRelative("attributeCollection").FindPropertyRelative("attributes");
            var itemNameProperty = property.FindPropertyRelative("itemName");

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            #region DrawProperty

            var nameRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            var buttonRect = new Rect(position.x, position.y + SpaceBetweenProperties, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.PropertyField(nameRect, itemNameProperty, new GUIContent("Name"), true);
            if (GUI.Button(buttonRect, "Add Attribute")) 
                AddAttributeToItem(attributes);
            _attributesHeights = new float[attributes.arraySize];
            DrawAttributes(position, attributes);

            #endregion

            EditorGUI.indentLevel = indent;
            
            EditorGUI.EndProperty();
        }

        private void DrawAttributes(Rect position, SerializedProperty attributes)
        {
            for (int i = 0; i < attributes.arraySize; i++)
            {
                var attrib = attributes.GetArrayElementAtIndex(i);
                var attribName = attrib.FindPropertyRelative("attributeName").stringValue;

                if (attribName == String.Empty) attribName = "Attribute";
                _attributesHeights[i] = GetAttributeHeight(attrib);

                Rect attribRect =
                    new Rect(position.x, position.y + SpaceBetweenProperties * 2, position.width,
                        EditorGUIUtility.singleLineHeight);
                
                if (i > 0)
                {
                    attribRect =
                        new Rect(
                            position.x,
                            position.y + SpaceBetweenProperties * 2 + SpaceBetweenProperties * i + 
                            (ArrayUtils.GetSumUntilIndex(_attributesHeights, i - 1) - EditorGUIUtility.singleLineHeight * i),
                            position.width,
                            EditorGUIUtility.singleLineHeight);
                }

                EditorGUI.PropertyField(attribRect, attrib, new GUIContent(attribName), true);
            }
        }

        private void AddAttributeToItem(SerializedProperty attributeProperty) => 
            attributeProperty.InsertArrayElementAtIndex(0);

        private float GetAttributeHeight(SerializedProperty attributeProperty) => 
            EditorGUI.GetPropertyHeight(attributeProperty, true);
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var attribs = property.FindPropertyRelative("attributeCollection").FindPropertyRelative("attributes");
            int attribCount = attribs.arraySize;
            float attribsHeight = 0;
            for (var i = 0; i < attribCount; i++)
            {
                attribsHeight += GetAttributeHeight(attribs.GetArrayElementAtIndex(i)) / EditorGUIUtility.singleLineHeight;
            }

            return
                SpaceBetweenProperties * 2 + SpaceBetweenProperties * attribsHeight + 12;
        }
    }
}