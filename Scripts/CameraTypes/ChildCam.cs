using HyperCasual_Engine.Camera;
using UnityEngine;

namespace HyperCasual_Engine.CameraTypes
{
    public class ChildCam : BaseCamera
    {
        protected override void Init(Transform tar)
        {
            base.Init(tar);
            transform.SetParent(target);
            transform.localPosition = Vector3.zero;
        }
    }
}