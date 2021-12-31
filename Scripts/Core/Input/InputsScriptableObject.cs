using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual_Engine
{
    [CreateAssetMenu(fileName = "Inputs", menuName = "HCE/inputs", order = 0)]
    public class InputsScriptableObject : ScriptableObject
    {
        [Header("Buttons")]
        public List<KeyboardButton> buttons;
        
        [Header("MouseEvents")]
        public List<MouseButton> mouseEvents;
        
        [Header("Axis list")]
        public List<Axis> axes;

        public static InputsScriptableObject CreateInstance(InputsScriptableObject reference)
        {
            var so = ScriptableObject.CreateInstance(typeof(InputsScriptableObject)) as InputsScriptableObject;
            so.buttons = reference.buttons;
            so.axes = reference.axes;
            so.mouseEvents = reference.mouseEvents;

            return so;
        }
    }
}