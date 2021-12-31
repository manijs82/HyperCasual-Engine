using UnityEngine;

namespace HyperCasual_Engine
{
    [System.Serializable]
    public class Axis
    {
        public string axisName;
        public bool smooth = true;

        public float GetValue()
        {
            if (smooth)
            {
                return Input.GetAxis(axisName);
            }

            return Input.GetAxisRaw(axisName);
        }
    }
}