using HyperCasual_Engine.Camera;
using UnityEngine;

namespace HyperCasual_Engine.CameraTypes
{
    public class ChildCam : BaseCamera
    {
        protected override void PreInit(Transform tar)
        {
            base.PreInit(tar);
            transform.SetParent(target);
            transform.localPosition = Vector3.zero;
        }
    }
}