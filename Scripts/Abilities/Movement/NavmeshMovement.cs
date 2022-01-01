using System;
using UnityEngine;
using UnityEngine.AI;

namespace HyperCasual_Engine.Abilities
{
    public class NavmeshMovement : MovementAbility
    {
        public event Action OnReachDestination;
        
        private NavMeshAgent _agent;
        private bool _isMoving;
        public override bool UseInUpdate => false;

        private bool HasReachedDestination
        {
            get
            {
                if (!_isMoving) return false;

                if (_agent.remainingDistance > _agent.stoppingDistance) return false;
                
                return !_agent.hasPath;
            }   
        }

        public override void Init()
        {
            base.Init();
            _agent = GetComponent<NavMeshAgent>();
            if(_agent == null)
                _agent = gameObject.AddComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(HasReachedDestination)
            {
                OnReachDestination?.Invoke();
                _isMoving = false;
            }
        }

        public void SetDestination(Vector3 position)
        {
            _agent.isStopped = false;
            _isMoving = true;
            _agent.SetDestination(position);
        }

        public void StopMovement()
        {
            _agent.isStopped = true;
            _agent.ResetPath();
        }
    }
}