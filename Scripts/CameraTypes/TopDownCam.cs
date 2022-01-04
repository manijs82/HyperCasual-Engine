﻿using HyperCasual_Engine.Camera;
using UnityEngine;

namespace HyperCasual_Engine.CameraTypes
{
    public class TopDownCam : BaseCamera
    {
        [SerializeField] private Vector3 movingOffset;
        [SerializeField] private CameraMovingTypes movingTypes;
        [SerializeField] private bool lookAtTarget;
        [SerializeField] private float smoothMoveSpeed;
        [SerializeField] private float maxDistanceFromTargetPosition;
        
        private Vector3 _targetPosition;
        
        protected override void FollowTarget()
        {
            _targetPosition = target.position + movingOffset;
            switch (movingTypes)
            {
                case CameraMovingTypes.Instant:
                    transform.position = _targetPosition;
                    break;
                case CameraMovingTypes.Smooth:
                    Vector3 pos = Vector3.MoveTowards(transform.position, _targetPosition, smoothMoveSpeed * Time.deltaTime);
                    
                    transform.position = pos;
                    break;
            }
        }

        protected override void LookAtTarget()
        {
            if(lookAtTarget)
                transform.LookAt(target);
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            transform.position = target.position + movingOffset;
        }
        #endif
    }
}