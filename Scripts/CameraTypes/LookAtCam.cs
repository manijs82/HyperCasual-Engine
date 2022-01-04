using HyperCasual_Engine.Camera;

namespace HyperCasual_Engine.CameraTypes
{
    public class LookAtCam : BaseCamera
    {
        protected override void LookAtTarget()
        {
            transform.LookAt(target);
        }
    }
}