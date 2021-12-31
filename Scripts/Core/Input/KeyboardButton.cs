using UnityEngine;

namespace HyperCasual_Engine
{
    [System.Serializable]
    public class KeyboardButton : Button
    {
        public KeyCode button;
        
        public override bool IsPressed()
        {
            return pressType switch
            {
                PressType.Hold => Input.GetKey(button),
                PressType.PressDown => Input.GetKeyDown(button),
                PressType.PressUp => Input.GetKeyUp(button),
                _ => false
            };
        }
    }
}