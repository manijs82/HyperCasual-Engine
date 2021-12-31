using HyperCasual_Engine.Abilities;
using HyperCasual_Engine.Inventory;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(CharacterInventory))]
    public class CharacterInventoryEditor : UnityEditor.Editor
    {
        private CharacterInventory _target;
        private string _itemName;
        
        public override void OnInspectorGUI()
        {
            _target = target as CharacterInventory;
            ItemDatabase database = _target.inventory.itemDatabase;

            base.OnInspectorGUI();
            
            EditorGUILayout.Separator();
            
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Item Name :", GUILayout.Width(80));
            _itemName = EditorGUILayout.TextField(_itemName);
            if (GUILayout.Button("Find and add item")) 
                _target.AddItemToInventory(_itemName, database);

            EditorGUILayout.EndHorizontal();
            
            if (GUILayout.Button("Remove Duplicates")) 
                _target.inventory.RemoveDuplicates();
        }
    }
}