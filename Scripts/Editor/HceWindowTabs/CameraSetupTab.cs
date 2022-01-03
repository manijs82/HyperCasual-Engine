using HyperCasual_Engine.Camera;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public class CameraSetupTab : HceWindowTab
    {
        private ReflectedTypes _cameraTypes;  
        private Transform _playerTr;

        public override void Init()
        {
            _cameraTypes = new ReflectedTypes(typeof(BaseCamera));   
        }

        public override void DrawTab()
        {
            _cameraTypes.TypeChoiceIndex =
                EditorGUILayout.Popup("Camera Type", _cameraTypes.TypeChoiceIndex, _cameraTypes.TypesNames);
            _playerTr = (Transform) EditorGUILayout.ObjectField("Player", _playerTr, typeof(Transform), true);

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