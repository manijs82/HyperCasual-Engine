using System;
using HyperCasual_Engine.Utils;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual_Engine
{
    [Serializable]
    public class UiComponent
    {
        private static string UNDO_MASSAGE = "Create UI Element"; 
        
        public UiType type;
        public string objectName;
        
        public GameObject CreateComponent(Transform parentObject, UiComponent parentComponent)
        {
            return type switch
            {
                UiType.Button => CreateButton(parentObject, parentComponent),
                UiType.Panel => CreatePanel(parentObject, parentComponent),
                UiType.Text => CreateText(parentObject, parentComponent),
                UiType.Background => CreateBackground(parentObject, parentComponent),
                UiType.Image => CreateBackground(parentObject, parentComponent),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameObject CreateButton(Transform parent, UiComponent parentComponent)
        {
            var gameObject = DefaultControls.CreateButton(new DefaultControls.Resources());
            UnityEngine.Object.DestroyImmediate(gameObject.GetComponentInChildren<Text>());
            var text = gameObject.transform.GetChild(0).gameObject.AddComponent<TextMeshProUGUI>();
            text.text = objectName;
            text.alignment = TextAlignmentOptions.Midline;
            text.color = Color.black;
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent);
            
            if (parentComponent is {type: UiType.Panel}) 
                gameObject.transform.SetParent(parent.GetChild(0));

            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);
            
            return gameObject;
        }
        
        private GameObject CreateText(Transform parent, UiComponent parentComponent)
        {
            var gameObject = DefaultControls.CreateText(new DefaultControls.Resources());
            UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<Text>());
            var text = gameObject.AddComponent<TextMeshProUGUI>();
            text.text = objectName;
            text.alignment = TextAlignmentOptions.Midline;
            text.color = Color.black;
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent);
            
            if (parentComponent is {type: UiType.Panel}) 
                gameObject.transform.SetParent(parent.GetChild(0));
            
            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);
            
            return gameObject;
        }
        
        private GameObject CreateImage(Transform parent, UiComponent parentComponent)
        {
            var gameObject = DefaultControls.CreateImage(new DefaultControls.Resources());
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent);
            
            if (parentComponent is {type: UiType.Panel}) 
                gameObject.transform.SetParent(parent.GetChild(0));
            
            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);
            
            return gameObject;
        }
        
        private GameObject CreatePanel(Transform parent, UiComponent parentComponent)
        {
            var panelPrefab = Resources.Load("Prefabs/UI/UiPanel");
            if (panelPrefab == null) return null;
            var gameObject = PrefabUtility.InstantiatePrefab(panelPrefab) as GameObject;
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent);

            if (parentComponent is {type: UiType.Button})
            {
                var parentObj = GameObject.Find(parentComponent.objectName);
                gameObject.transform.SetParent(parentObj.transform.parent);
                var button = parentObj.GetComponent<UnityEngine.UI.Button>();
                var panel = gameObject.GetComponent<UiPanel>();
                panel.openButton = button;
                panel.Close();
            }
            gameObject.GetComponent<RectTransform>().MakeFullScreen();
            
            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);

            return gameObject;
        }
        
        private GameObject CreateBackground(Transform parent, UiComponent parentComponent)
        {
            var panelPrefab = Resources.Load("Prefabs/UI/Background");
            if (panelPrefab == null) return null;
            var gameObject = PrefabUtility.InstantiatePrefab(panelPrefab) as GameObject;
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent);
            gameObject.GetComponent<RectTransform>().MakeFullScreen();
            
            if (parentComponent is {type: UiType.Panel})
            {
                gameObject.transform.SetParent(parent.GetChild(0));
                gameObject.transform.SetAsFirstSibling();
            }

            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);
            
            return gameObject;
        }

        public enum UiType
        {
            Button,
            Panel,
            Text,
            Background,
            Image
        }
    }
}