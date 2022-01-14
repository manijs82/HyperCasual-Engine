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

        [HideInInspector] public Transform transform;
        [HideInInspector] public Image image;
        [HideInInspector] public UnityEngine.UI.Button button;
        [HideInInspector] public TextMeshProUGUI textMesh;
        
        public void CreateComponent(Transform canvas, UiComponent parentComponent, bool isRoot = false)
        {
            switch (type)
            {
                case UiType.Button:
                    CreateButton(isRoot ? canvas : parentComponent.transform);
                    break;
                case UiType.Panel:
                    CreatePanel(isRoot ? canvas : parentComponent.transform);
                    break;
                case UiType.Text:
                    break;
            }
        }

        private void CreateButton(Transform parent)
        {
            DefaultControls.Resources uiResources = new DefaultControls.Resources();
            var obj = DefaultControls.CreateButton(uiResources);
            obj.name = objectName;
            obj.transform.SetParent(parent);
            transform = obj.transform;
        }
        
        private void CreatePanel(Transform parent)
        {
            DefaultControls.Resources uiResources = new DefaultControls.Resources();
            var obj = DefaultControls.CreatePanel(uiResources);
            obj.name = objectName;
            obj.transform.SetParent(parent);
            transform = obj.transform;
            obj.GetComponent<RectTransform>().StretchToAllSides();
        }

        public enum UiType
        {
            Button,
            Panel,
            Text
        }
    }
}