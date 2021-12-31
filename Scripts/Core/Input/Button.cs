using System;

namespace HyperCasual_Engine
{
    [Serializable]
    public abstract class Button
    {
        public enum PressType
        {
            PressDown,
            Hold,
            PressUp
        }
        
        public event Action ClickEvent;

        public string inputName;
        public PressType pressType;

        public void CheckForClick()
        {
            if(IsPressed()) ClickEvent?.Invoke();
        }

        public abstract bool IsPressed();

        public void AddListener(Action action)
        {
            ClickEvent += action;
        }
        
        public void RemoveListener(Action action)
        {
            ClickEvent -= action;
        }
    }
}