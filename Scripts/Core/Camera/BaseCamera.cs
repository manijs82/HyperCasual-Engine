using System;
using UnityEngine;

namespace HyperCasual_Engine.Camera
{
    public class BaseCamera : MonoBehaviour
    {
        public static BaseCamera Clone(Type type, Transform target)
        {
            var go = new GameObject("Camera");
            go.AddComponent<UnityEngine.Camera>();
            go.AddComponent<AudioListener>();
            var cameraComp = go.AddComponent(type) as BaseCamera;
            cameraComp.PreInit(target);
            
            return cameraComp;
        }
        
        [SerializeField] protected Transform target;

        protected virtual void PreInit(Transform tar)
        {
            target = tar;
        }

        protected virtual void Update()
        {
            FollowTarget();
            LookAtTarget();
        }

        protected virtual void FollowTarget()
        {
            
        }

        protected virtual void LookAtTarget()
        {
            
        }
    }
}