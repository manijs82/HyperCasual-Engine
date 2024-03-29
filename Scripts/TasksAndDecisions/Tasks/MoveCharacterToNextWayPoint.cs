﻿using HyperCasual_Engine.Abilities;
using HyperCasual_Engine.LevelCreation;
using UnityEngine;

namespace HyperCasual_Engine.TasksAndDecisions.Tasks
{
    public class MoveCharacterToNextWayPoint : Task
    {
        [SerializeField] private Character character;
        [SerializeField] private WayPointHandler wayPointHandler;
        [SerializeField] private bool deActiveOtherAbilities = true;
        
        private NavmeshMovement _movement;

        private void Start()
        {
            if (!character.HasAbility<NavmeshMovement>()) 
                character.CreateAndAddAbility<NavmeshMovement>();

            _movement = character.GetAbility<NavmeshMovement>() as NavmeshMovement;
        }

        public override void PerformTask()
        {
            if (!canPerformTask) return;
            if (deActiveOtherAbilities) 
                ActivateOtherAbilities(false);

            _movement.SetDestination(wayPointHandler.GetNextWayPointPosition(out bool wasLastWayPoint));
            _movement.OnReachDestination += OnTaskEnd;

            if (wasLastWayPoint)
                canPerformTask = false;
        }

        protected override void OnTaskEnd()
        {
            _movement.OnReachDestination -= OnTaskEnd;
            _movement.StopMovement();
            ActivateOtherAbilities(true);

            base.OnTaskEnd();
        }

        private void ActivateOtherAbilities(bool active)
        {
            var abilities = character.abilities;
            abilities.Remove(abilities.Find(a => a.GetType() == typeof(NavmeshMovement)));

            foreach (Ability ability in abilities) 
                ability.IsActive = active;
        }
    }
}