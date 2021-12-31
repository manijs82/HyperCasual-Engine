using UnityEngine;

namespace HyperCasual_Engine.TasksAndDecisions.Tasks
{
    public class ActivateCharacterAbility : Task
    {
        [SerializeField] private bool setActive;
        [SerializeField] private Ability ability;
        
        public override void PerformTask()
        {
            ability.IsActive = setActive;
        }
    }
}