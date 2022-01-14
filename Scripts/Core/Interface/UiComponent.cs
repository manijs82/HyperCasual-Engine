using System;
using HyperCasual_Engine.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HyperCasual_Engine
{
    [Serializable]
    public class UiComponent
    {
        public UiType type;
        public string objectName;

        [HideInInspector] public Transform tfObject;
        [HideInInspector] public Image image;
        [HideInInspector] public UnityEngine.UI.Button button;
        [HideInInspector] public TextMeshProUGUI textMesh;
        
        public void CreateComponent(Transform canvas, UiComponent parentComponent, bool isRoot)
        {
            switch (type)
            {
                case UiType.Button:
                    CreateButton(isRoot ? canvas : parentComponent.tfObject);
                    break;
                case UiType.Panel:
                    CreatePanel(isRoot ? canvas : parentComponent.tfObject);
                    break;
                case UiType.Text:
                    break;
            }
        }

        private void CreateButton(Transform parent)
        {
            tfObject = new GameObject(objectName).transform;
            tfObject.SetParent(parent);

            image = tfObject.gameObject.AddComponent<Image>();
            button = tfObject.gameObject.AddComponent<UnityEngine.UI.Button>();
            var textObj = new GameObject("Text");
            textObj.transform.SetParent(tfObject);
            textMesh = textObj.AddComponent<TextMeshProUGUI>();
            textMesh.text = objectName;
        }
        
        private void CreatePanel(Transform parent)
        {
            tfObject = new GameObject(objectName).transform;
            tfObject.SetParent(parent);

            image = tfObject.gameObject.AddComponent<Image>();
            image.rectTransform.StretchToAllSides();
            
        }

        public enum UiType
        {
            Button,
            Panel,
            Text
        }
    }
}