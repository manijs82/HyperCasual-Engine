using UnityEngine;

namespace HyperCasual_Engine.Utils
{
    public static class MouseUtils
    {
        public static GameObject GetMouseClickedObject(UnityEngine.Camera cam)
        {
            var ray = MouseUtils.GetMouseRay(cam);
            return Physics.Raycast(ray, out var hitInfo) ? hitInfo.collider.gameObject : null;
        }
        
        public static Ray GetMouseRay(UnityEngine.Camera cam) => cam.ScreenPointToRay(Input.mousePosition);
    }
}