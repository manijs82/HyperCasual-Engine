using UnityEngine;
using UnityEngine.Events;

namespace HyperCasual_Engine
{
    public class UiPanel : MonoBehaviour
    {
        public enum Method { ButtonPress, UiButton, Both }
        public enum Style { Activation, Animation }
        
        public Method openingAndClosingMethod;
        public Style openingAndClosingStyle;
        public InputManager inputManager;
        public UnityEngine.UI.Button openButton;
        public UnityEngine.UI.Button closeButton;
        public UnityEvent onPanelOpen;
        public UnityEvent onPanelClose;

        private Animator _animator;
        private bool _isOpen;
        private GameObject _panelObject;

        private readonly int _open = Animator.StringToHash("Open");
        private readonly int _close = Animator.StringToHash("Close");

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _panelObject = transform.GetChild(0).gameObject;
            if (inputManager == null) inputManager = FindObjectOfType<InputManager>();
            InitializeOpeningEvent();
        }

        public void Toggle()
        {
            if(_isOpen)
            {
                Close();
                return;
            }
            Open();
        }

        public void Open()
        {
            if (_isOpen) return;

            _isOpen = true;
            ActivatePanel(true);
            
            onPanelOpen?.Invoke();
        }

        public void Close()
        {
            if (!_isOpen) return;

            _isOpen = false;
            ActivatePanel(false);
            
            onPanelClose?.Invoke();
        }

        private void ActivatePanel(bool active)
        {
            if (openingAndClosingStyle == Style.Activation) _panelObject.SetActive(active);
            if(openingAndClosingStyle == Style.Animation) _animator.SetTrigger(active ? _open : _close);
        }

        private void InitializeOpeningEvent()
        {
            if (openingAndClosingMethod == Method.UiButton || openingAndClosingMethod == Method.Both)
            {
                openButton.onClick.AddListener(Open);
                closeButton.onClick.AddListener(Close);
            }
            if(openingAndClosingMethod == Method.ButtonPress || openingAndClosingMethod == Method.Both) 
                inputManager.AddListenerToButton("Pause", Toggle);
        }
        
        private void DeInitializeOpeningEvent()
        {
            if (openingAndClosingMethod == Method.UiButton || openingAndClosingMethod == Method.Both)
            {
                openButton.onClick.RemoveListener(Open);
                closeButton.onClick.RemoveListener(Close);
            }
            if(openingAndClosingMethod == Method.ButtonPress || openingAndClosingMethod == Method.Both) 
                inputManager.RemoveListenerToButton("Pause", Toggle);
        }

        private void OnDisable()
        {
            DeInitializeOpeningEvent();
        }
    }
}