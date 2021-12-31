using UnityEngine;

namespace HyperCasual_Engine
{
    [System.Serializable]
    public class MouseButton : Button
    {        
        public enum MouseButtonType
        {
            LeftClick,
            RightClick,
            MiddleClick
        }

        [SerializeField] private MouseButtonType mouseButtonType;

        public override bool IsPressed()
        {
            return pressType switch
            {
                PressType.Hold => Input.GetMouseButton((int) mouseButtonType),
                PressType.PressDown => Input.GetMouseButtonDown((int) mouseButtonType),
                PressType.PressUp => Input.GetMouseButtonUp((int) mouseButtonType),
                _ => false
            };
        }
    }
}