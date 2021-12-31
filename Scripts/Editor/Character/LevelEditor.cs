using HyperCasual_Engine.LevelCreation;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    [CustomEditor(typeof(LevelEditorObject))]
    public class LevelEditor : UnityEditor.Editor
    {
        private LevelEditorObject _target;
        private Vector3 _cameraPos;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _target = target as LevelEditorObject;
        }

        private void OnSceneGUI()
        {
            _cameraPos = SceneView.currentDrawingSceneView.camera.transform.position;

            for (int x = _target.gridSize; x > -_target.gridSize; x--)
            {
                for (int y = _target.gridSize; y > -_target.gridSize; y--)
                {
                    InitializeButtons(x, y);
                }
            }
        }

        private void InitializeButtons(int xPos, int yPos)
        {
            var cameraX = (Mathf.Floor(_cameraPos.x / _target.gridCellSize)) * _target.gridCellSize;
            var cameraZ = (Mathf.Floor(_cameraPos.z / _target.gridCellSize)) * _target.gridCellSize;

            var buttonOrigin = new Vector3(cameraX, _target.heightLevel, cameraZ) +
                               new Vector3(_target.gridCellSize * xPos, 0, _target.gridCellSize * yPos);

            Handles.color = Color.gray;
            if (Handles.Button(buttonOrigin, Quaternion.Euler(90, 0, 0), _target.gridCellSize, _target.gridCellSize,
                Handles.RectangleHandleCap))
            {
                PlacePrefab(buttonOrigin - Vector3.one * (_target.gridCellSize * -.5f));
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