using System;
using HyperCasual_Engine.Camera;
using HyperCasual_Engine.Utils;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class HceWindow : EditorWindow
    {
        private readonly string[] _tabNames = {"Magic Buttons", "Camera", "Level"};
        private int _tabIndex;
        
        private Transform _playerTr;
        private ReflectedTypes _cameraTypes;

        [MenuItem("HCE/Window")]
        private static void ShowWindow()
        {
            var window = GetWindow<HceWindow>();
            window.titleContent = new GUIContent("Hce Editor");
            window.Show();
        }

        private void OnEnable()
        {
            _cameraTypes = new ReflectedTypes(typeof(BaseCamera));
        }

        private void OnGUI()
        {
            _tabIndex = GUILayout.Toolbar(_tabIndex, _tabNames);
            switch (_tabIndex)
            {
                case 0:
                    break;
                case 1:
                    DrawCameraSetup();
                    break;
                default:
                    break;
            }
        }

        private void DrawMagicButtons()
        {
            if (GUILayout.Button("SetUp Scene"))
            {
                MagicButtons.SetUpScene();
            }
        }

        private void DrawCameraSetup()
        {
            _cameraTypes.TypeChoiceIndex = EditorGUILayout.Popup("Camera Type", _cameraTypes.TypeChoiceIndex, _cameraTypes.TypesNames);
            _playerTr = (Transform)EditorGUILayout.ObjectField("Player", _playerTr, typeof(Transform), true);

            EditorGUILayout.Separator();
            if (GUILayout.Button("Create Camera")) SetupPlayerCamera();
        }
        
        private void SetupPlayerCamera()
        {
            var cam = BaseCamera.Clone(_cameraTypes.Types[_cameraTypes.TypeChoiceIndex], _playerTr);
            Undo.RegisterCreatedObjectUndo(cam.gameObject, "SetUp Components");
        }
    }
}