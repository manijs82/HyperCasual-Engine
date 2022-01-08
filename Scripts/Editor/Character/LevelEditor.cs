using HyperCasual_Engine.LevelCreation;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(LevelEditorObject))]
    public class LevelEditor : UnityEditor.Editor
    {
        private LevelEditorObject _target;
        private SerializedProperty _propGridDistance; 

        public void OnEnable()
        {
            _target = target as LevelEditorObject;
            _propGridDistance = serializedObject.FindProperty("gridDistance");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            
            if (_propGridDistance.intValue % 2 != 0)
                _propGridDistance.intValue++;
            
            serializedObject.ApplyModifiedProperties();
        }

        private void OnSceneGUI()
        {
            int gridWidth = _target.gridDistance / _target.gridCellSize;
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridWidth; y++)
                {
                    float btnXPos = (x - gridWidth / 2) * _target.gridCellSize;
                    float btnYPos = (y - gridWidth / 2) * _target.gridCellSize;
                    btnXPos += _target.gridCellSize / 2f;
                    btnYPos += _target.gridCellSize / 2f;
                    InitializeButtons(btnXPos, btnYPos);
                }
            }
        }

        private void InitializeButtons(float xPos, float yPos)
        {
            var buttonOrigin = new Vector3(xPos, _target.heightLevel, yPos);

            Handles.color = Color.gray;
            Handles.zTest = CompareFunction.LessEqual;
            if (Handles.Button(buttonOrigin, Quaternion.Euler(90, 0, 0), _target.gridCellSize / 2f, _target.gridCellSize / 2f,
                Handles.RectangleHandleCap))
            {
                PlacePrefab(buttonOrigin);
            }
        }

        private void PlacePrefab(Vector3 pos)
        {
            if (_target.prefab == null) return;

            GameObject obj = PrefabUtility.InstantiatePrefab(_target.prefab) as GameObject;
            obj.transform.position = pos;
            
            if(_target.scalePrefab)
                obj.transform.localScale = Vector3.one * _target.gridCellSize;
            
            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
        }
    }
}