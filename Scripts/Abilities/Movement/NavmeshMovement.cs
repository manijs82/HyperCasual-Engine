using System;
using UnityEngine;
using UnityEngine.AI;

namespace HyperCasual_Engine.Abilities
{
    public class NavmeshMovement : MovementAbility
    {
        public event Action OnReachDestination;
        
        private NavMeshAgent _agent;
        public override bool UseInUpdate => false;

        public override void Init()
        {
            base.Init();
            _agent = gameObject.AddComponent<NavMeshAgent>();
            _agent.isStopped = true;
        }

        private void Update()
        {
            if (_agent.pathPending) return;
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _agent.isStopped = true;
                _agent.ResetPath();
                
                OnReachDestination?.Invoke();
            }
        }

        public void SetDestination(Vector3 position)
        {
            _agent.isStopped = false;
            _agent.SetDestination(position);
        }
    }
}