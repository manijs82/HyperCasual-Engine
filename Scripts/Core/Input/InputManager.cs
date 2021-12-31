using System;
using System.Linq;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputsScriptableObject inputScriptableObject;
        [SerializeField] private Axis horizontalAxis;
        [SerializeField] private Axis verticalAxis;
        
        [HideInInspector] public float horizontal;
        [HideInInspector] public float vertical;
        
        private InputsScriptableObject _inputSo;

        private void Awake()
        {
            _inputSo = InputsScriptableObject.CreateInstance(inputScriptableObject);
        }

        private void Update()
        {
            horizontal = horizontalAxis.GetValue();
            vertical = verticalAxis.GetValue();

            foreach (var button in _inputSo.buttons) button.CheckForClick();

            foreach (var mouseEvent in _inputSo.mouseEvents) mouseEvent.CheckForClick();
        }

        public void AddListenerToButton(string buttonName, Action action)
        {
            _inputSo.buttons.FirstOrDefault(b => b.inputName == buttonName)?.AddListener(action);
        }
        
        public void RemoveListenerToButton(string buttonName, Action action)
        {
            _inputSo.buttons.FirstOrDefault(b => b.inputName == buttonName)?.RemoveListener(action);
        }
        
        public void AddListenerToMouseClick(string buttonName, Action action)
        {
            _inputSo.mouseEvents.FirstOrDefault(m => m.inputName == buttonName)?.AddListener(action);
        }
        
        public void RemoveListenerToMouseClick(string buttonName, Action action)
        {
            _inputSo.mouseEvents.FirstOrDefault(m => m.inputName == buttonName)?.RemoveListener(action);
        }

        public Axis GetAxis(string axisName)
        {
            return _inputSo.axes.FirstOrDefault(a => a.axisName == axisName);
        }
    }
}