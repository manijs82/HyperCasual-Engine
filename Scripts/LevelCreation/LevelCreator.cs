using UnityEditor;
using UnityEngine;
using Grid = HyperCasual_Engine.Utils.Grid;

namespace HyperCasual_Engine.LevelCreation
{
    [ExecuteAlways]
    public class LevelCreator : MonoBehaviour
    {
        public GameObject prefab;
        [Range(1,20)]
        public int gridCellSize = 1;
        [Min(1)]
        public int scale = 1;
        public bool snapPlacement = true;
        public bool drawGrid;
        
        private Plane _plane;
        private Grid _grid;
        private GameObject _previewGameObject;
        
        public void Init()
        {
            _plane = new Plane(Vector3.up, transform.position.y);
            _grid = new Grid(30, 30, gridCellSize, transform.position);
        }
        
        private void OnEnable()
        {
            Selection.selectionChanged -= DestroyPreviewGameObject;
            Selection.selectionChanged += DestroyPreviewGameObject;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            if(Selection.activeTransform == null) return;
            if(Selection.activeGameObject.GetComponent<LevelCreator>() == null) return;

            DrawMeshPreview(sceneView);
            if(drawGrid)
                _grid.DrawGrid();
            
            var e = Event.current;

            if (e.control)
            {
                if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Space)
                {
                    e.Use();
                    EraseObject();
                }
                return;
            }

            if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Space)
            {
                e.Use();
                PlacePrefab();
            }
        }

        private void OnDisable()
        {
            if (_previewGameObject != null) DestroyImmediate(_previewGameObject);
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private void DrawMeshPreview(SceneView sceneView)
        {
            if(prefab == null) return;

            var previewPos = TryGetDesiredPosition(out bool hit);
            if (hit)
            {
                if(_previewGameObject == null) CreatePreviewGameObject();
                _previewGameObject.transform.position = previewPos;
                _previewGameObject.transform.localScale = Vector3.one * scale;
                sceneView.Repaint();
                return;
            }
            
            DestroyPreviewGameObject();
        }

        private Vector3 TryGetDesiredPosition(out bool hit)
        {
            Ray ray = GetMouseRay();

            if (_plane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                hit = true;
                if(snapPlacement)
                    return _grid.GetGridPosition(hitPoint);
                return hitPoint;
            }

            hit = false;
            return default;
        }

        private void PlacePrefab()
        {
            if (_previewGameObject == null) return;
            Ray ray = GetMouseRay();

            if (_plane.Raycast(ray, out float enter))
                if (Physics.Raycast(ray, enter)) return;

            _previewGameObject.hideFlags = HideFlags.None;
            Undo.RegisterCreatedObjectUndo(_previewGameObject, "Create " + _previewGameObject.name);

            _previewGameObject = null;
        }
        
        private void EraseObject()
        {
            Ray ray = GetMouseRay();

            if (Physics.Raycast(ray, out RaycastHit hit)) 
                DestroyImmediate(hit.collider.gameObject);
        }

        private void CreatePreviewGameObject()
        {
            if (prefab == null) return;

            if (_previewGameObject != null) DestroyImmediate(_previewGameObject);
            _previewGameObject = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            _previewGameObject.hideFlags = HideFlags.HideAndDontSave;
        }
        
        private void DestroyPreviewGameObject()
        {
            if (_previewGameObject == null) return;

            if (_previewGameObject != null) DestroyImmediate(_previewGameObject);
            _previewGameObject = null;
        }

        private Ray GetMouseRay() => HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
    }
}