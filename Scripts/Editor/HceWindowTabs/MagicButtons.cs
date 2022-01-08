using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.Editor
{
    public static class MagicButtons
    {
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
            playerCore.playerVisuals = PlayerVisualsType.Cube;
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
            
            
        }
        
    }
}