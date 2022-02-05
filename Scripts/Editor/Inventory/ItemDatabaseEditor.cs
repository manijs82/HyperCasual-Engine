using System;
using HyperCasual_Engine.Attributes;
using HyperCasual_Engine.Inventory;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(ItemDatabase))]
    public class ItemDatabaseEditor : UnityEditor.Editor
    {
        private ItemDatabase _database;
        private string _newItemName;
        
        private void OnEnable()
        {
            _database = (ItemDatabase) target;
        }

        public override void OnInspectorGUI()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                if(GUILayout.Button("Add Item")) AddItemToDatabase(_newItemName);
                EditorGUILayout.LabelField("New Item Name", GUILayout.Width(100));
                _newItemName = EditorGUILayout.TextField(_newItemName);
            }
            EditorGUILayout.Space();

            var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold};
            EditorGUILayout.LabelField("Item Definitions", style, GUILayout.ExpandWidth(true));
            DrawLine();
            EditorGUILayout.Space();
            for (var i = 0; i < _database.itemDefinitions.Count; i++) 
                DrawItem(_database.itemDefinitions[i]);
        }

        private void DrawItem(ItemDefinition definition)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField("Name", GUILayout.Width(40));
                definition.itemName = EditorGUILayout.TextField(definition.itemName);
                if(GUILayout.Button("-", GUILayout.Width(20))) RemoveItemFromDatabase(definition);
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                if(GUILayout.Button("Add Attribute")) AddAttributeToItem(definition);
                EditorGUILayout.LabelField("New Attribute Type", GUILayout.Width(130));
                definition.nextAttributeType = (AttributeType) EditorGUILayout.EnumPopup(definition.nextAttributeType);
            }

            EditorGUILayout.Space();
            for (var i = 0; i < definition.attributeCollection.Count; i++) 
                DrawAttribute(definition.attributeCollection, definition.attributeCollection.attributes[i]);
            EditorGUILayout.Space();
            DrawLine();
            EditorGUILayout.Space();
        }

        private void DrawAttribute(AttributeCollection collection, AttributeBase attribute)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField("Attribute Name", GUILayout.Width(100));
                attribute.attributeName = EditorGUILayout.TextField(attribute.attributeName);
                if(GUILayout.Button("-", GUILayout.Width(20))) RemoveAttributeFromItem(collection, attribute);
            }
            DrawAttributeValue(attribute);
            EditorGUILayout.Space();
        }
        
        private void DrawAttributeValue(AttributeBase attribute)
        {
            switch (attribute.attributeType)
            {
                case AttributeType.Int:
                attribute.SetValue(EditorGUILayout.IntField("Int Value", (int)attribute.GetValue()));
                    break;
                case AttributeType.Text:
                    break;
                case AttributeType.Bool:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddItemToDatabase(string itemName)
        {
            Undo.RecordObject(_database, "Add Item To Database");
            _database.AddItem(itemName);
        }
        
        private void RemoveItemFromDatabase(ItemDefinition definition)
        {
            Undo.RecordObject(_database, "Remove Item From Database");
            _database.RemoveItem(definition);
        }
        
        private void AddAttributeToItem(ItemDefinition definition)
        {
            Undo.RecordObject(_database, "Add Attribute To Item");
            var attrib = AttributeTypeCast.GetAttributeFromType(definition.nextAttributeType);
            definition.attributeCollection.AddAttribute(attrib);
        }
        
        private void RemoveAttributeFromItem(AttributeCollection collection, AttributeBase attribute)
        {
            Undo.RecordObject(_database, "Remove Attribute From Item");
            collection.RemoveAttribute(attribute);
        }
        
        private void DrawLine() => GUILayout.Box(GUIContent.none, GUILayout.Width(Screen.width), GUILayout.Height(2));
    }
}