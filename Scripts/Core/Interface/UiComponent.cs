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

        [HideInInspector] public GameObject gameObject;
        
        public void CreateComponent(GameObject canvas, UiComponent parentComponent, bool isRoot = false)
        {
            switch (type)
            {
                case UiType.Button:
                    CreateButton(isRoot ? canvas : parentComponent.gameObject);
                    break;
                case UiType.Panel:
                    CreatePanel(isRoot ? canvas : parentComponent.gameObject);
                    break;
                case UiType.Text:
                    break;
            }
        }

        private void CreateButton(GameObject parent)
        {
            gameObject = CreateGameObject(() => DefaultControls.CreateButton(new DefaultControls.Resources()));
            UnityEngine.Object.DestroyImmediate(gameObject.GetComponentInChildren<Text>());
            var text = gameObject.transform.GetChild(0).gameObject.AddComponent<TextMeshProUGUI>();
            text.text = objectName;
            text.alignment = TextAlignmentOptions.Midline;
            text.color = Color.black;
            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent.transform);
        }
        
        private void CreatePanel(GameObject parent)
        {
            gameObject = CreateGameObject(() => DefaultControls.CreatePanel(new DefaultControls.Resources()));
            Undo.RegisterCreatedObjectUndo(gameObject, UNDO_MASSAGE);
            gameObject.name = objectName;
            gameObject.transform.SetParent(parent.transform);
            gameObject.GetComponent<RectTransform>().StretchToAllSides();
            var group = gameObject.AddComponent<VerticalLayoutGroup>();
            group.childAlignment = TextAnchor.MiddleCenter;
        }

        private GameObject CreateGameObject(Func<GameObject> createFunction)
        {
            GameObject obj = createFunction.Invoke();
            return obj;
        }

        public enum UiType
        {
            Button,
            Panel,
            Text
        }
    }
}