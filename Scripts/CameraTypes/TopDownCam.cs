using HyperCasual_Engine.Camera;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine.CameraTypes
{
    public class TopDownCam : BaseCamera
    {
        [SerializeField] private Vector3 movingOffset;
        [SerializeField] private CameraMovingTypes movingTypes;
        [SerializeField] private bool lookAtTarget;
        [SerializeField] private float smoothMoveSpeed = 4;
        [SerializeField] private float maxDistanceFromTargetPosition = 3;
        
        private Vector3 _targetPosition;
        private Vector3 _currentPosition;
        
        protected override void FollowTarget()
        {
            _targetPosition = GetTargetPosition();
            switch (movingTypes)
            {
                case CameraMovingTypes.Instant:
                    transform.position = _targetPosition;
                    break;
                case CameraMovingTypes.Smooth:
                    _currentPosition = Vector3.MoveTowards(transform.position, _targetPosition, smoothMoveSpeed * Time.deltaTime);
                    float distanceFromTarget = (_targetPosition - _currentPosition).magnitude;
                    if (distanceFromTarget > maxDistanceFromTargetPosition)
                        _currentPosition = _targetPosition + (_currentPosition - _targetPosition).normalized * maxDistanceFromTargetPosition;

                    transform.position = _currentPosition;
                    break;
            }
        }

        protected override void LookAtTarget()
        {
            if(lookAtTarget)
                transform.LookAt(target);
        }

        private Vector3 GetTargetPosition()
        {
            return target.TransformPoint(movingOffset);
        }

        #if UNITY_EDITOR

        private void OnValidate()
        {
            SceneView.RepaintAll();
        }

        private void OnDrawGizmos()
        {
            transform.position = GetTargetPosition();
        }
        #endif
    }
}