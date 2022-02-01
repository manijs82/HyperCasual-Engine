using HyperCasual_Engine.LevelCreation;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(LevelCreator))]
    public class LevelCreatorEditor : UnityEditor.Editor
    {
        private LevelCreator _target;

        private SerializedProperty propPrefab;
        private SerializedProperty propGridCellSize;
        private SerializedProperty propScale;
        private SerializedProperty propSnapPlacement;
        private SerializedProperty propDrawGrid;

        public void OnEnable()
        {
            _target = target as LevelCreator;
            propPrefab = serializedObject.FindProperty("prefab");
            propGridCellSize = serializedObject.FindProperty("gridCellSize");
            propScale = serializedObject.FindProperty("scale");
            propSnapPlacement = serializedObject.FindProperty("snapPlacement");
            propDrawGrid = serializedObject.FindProperty("drawGrid");
            
            InitLevelCreator();
        }

        private void InitLevelCreator()
        {
            _target.Init();
            Repaint();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.HelpBox("Place object : space\n" +
                                    "Erase object : ctrl+space\n" +
                                    "Change Scale : ctrl+mouse wheel" +
                                    "Toggle Snapping : ctrl+left mouse click", MessageType.Info);
            
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(propPrefab);
            EditorGUILayout.PropertyField(propGridCellSize);
            EditorGUILayout.PropertyField(propScale);
            EditorGUILayout.PropertyField(propSnapPlacement);
            EditorGUILayout.PropertyField(propDrawGrid);
            
            if (serializedObject.ApplyModifiedProperties()) 
                InitLevelCreator();
            
            if(_target.transform.hasChanged)
                InitLevelCreator();
        }

        private void OnSceneGUI()
        {
            var e = Event.current;
            
            if (e.control)
            {
                if (e.type == EventType.ScrollWheel)
                {
                    e.Use();
                    serializedObject.Update();
                    
                    propScale.intValue += (int)-e.delta.normalized.y;
                    propScale.intValue = Mathf.Max(1, propScale.intValue);

                    serializedObject.ApplyModifiedProperties();
                }
                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    e.Use();
                    serializedObject.Update();

                    propSnapPlacement.boolValue = !propSnapPlacement.boolValue; 

                    serializedObject.ApplyModifiedProperties();
                }
            }
        }
    }
}