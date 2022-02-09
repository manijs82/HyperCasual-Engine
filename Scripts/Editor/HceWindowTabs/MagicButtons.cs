using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HyperCasual_Engine.Editor
{
    public static class MagicButtons
    {
        #if UNITY_EDITOR
        
        public static void SetUpLevel()
        {
            // clean the scene
            foreach (var tr in Object.FindObjectsOfType<Transform>())
            {
                Undo.DestroyObjectImmediate(tr.gameObject);
            }
            
            // make the directional light
            GameObject directionalLight = new GameObject("Directional Light");
            Light lightComponent = directionalLight.AddComponent<Light>();
            lightComponent.type = LightType.Directional;
            lightComponent.shadows = LightShadows.Soft;
            directionalLight.transform.position = Vector3.up * 10;
            directionalLight.transform.eulerAngles = new Vector3(50, -30, 0);
            
            // make the ground
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ground.transform.localScale = new Vector3(30, 1, 30);
            var groundMaterial = Resources.Load<Material>("Materials/Ground");
            if (groundMaterial != null)
                ground.GetComponent<Renderer>().material = groundMaterial;

            // set up input manager
            GameObject inputManager = new GameObject("InputManager");
            inputManager.transform.position = Vector3.zero;
            InputManager imComponent = inputManager.AddComponent<InputManager>();
            var inputManagerSo = Resources.Load<InputsScriptableObject>("ScriptableObjects/Inputs");
            imComponent.SetScriptableObject(inputManagerSo);
            
            // set up player
            GameObject player = new GameObject("Player");
            CharacterCore playerCore = player.AddComponent<CharacterCore>();
            player.transform.position = Vector3.up;
            playerCore.characterVisuals = PlayerVisualsType.Cube;
            playerCore.CreatePlayerVisuals();
            
            // set up camera
            GameObject camera = new GameObject("Camera");
            camera.AddComponent<UnityEngine.Camera>();
            camera.transform.position = new Vector3(0, 5, -10);
            camera.tag = "MainCamera";
            
            Undo.RegisterCreatedObjectUndo(directionalLight, "set up scene");
            Undo.RegisterCreatedObjectUndo(ground, "set up scene");
            Undo.RegisterCreatedObjectUndo(inputManager, "set up scene");
            Undo.RegisterCreatedObjectUndo(player, "set up scene");
            Undo.RegisterCreatedObjectUndo(camera, "set up scene");
        }

        public static void SetUpMainMenu()
        {
            // clean the scene
            foreach (var tr in Object.FindObjectsOfType<Transform>())
            {
                Undo.DestroyObjectImmediate(tr.gameObject);
            }
            
            // set up camera
            GameObject camera = new GameObject("Camera");
            camera.AddComponent<UnityEngine.Camera>();
            camera.transform.position = new Vector3(0, 1, -10);
            camera.tag = "MainCamera";
            
            // set up Canvas
            GameObject canvas = new GameObject("Canvas");
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas.AddComponent<GraphicRaycaster>();
            canvas.AddComponent<UiCreator>();
            
            // set up EventSystem
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
            
            Undo.RegisterCreatedObjectUndo(camera, "set up scene");
            Undo.RegisterCreatedObjectUndo(canvas, "set up scene");
            Undo.RegisterCreatedObjectUndo(eventSystem, "set up scene");
        }

        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
        
        public static void ClearPersistentDataPath()
        {
            DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete(); 
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true); 
            }
        }

        public static void OpenPersistentDataPath()
        {
            Process.Start(Application.persistentDataPath);
        }

        public static void ParentSelectedObject(string parentName)
        {
            if(Selection.count == 0) return;
            
            var selectedObjects = Selection.transforms;
            var newParent = new GameObject(parentName).transform;
            Undo.RegisterCreatedObjectUndo(newParent.gameObject, "Set parents");
            foreach (var transform in selectedObjects)
            {
                Undo.SetTransformParent(transform, newParent, "Set parents");
            }

            Selection.activeObject = newParent.gameObject;
        }
        
        #endif
    }
}