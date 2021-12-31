using HyperCasual_Engine.Abilities;
using UnityEngine;

namespace HyperCasual_Engine.TasksAndDecisions
{
    public class CharacterHasDied : Decision
    {
        [SerializeField] private Health characterHealth;

        protected override void MakeDecision()
        {
            InvokeDecision(true, stateOnTrue, stateOnFalse);
        }

        protected override void OnGetListener()
        {
            characterHealth.OnDeath.AddListener(MakeDecision);
        }

        protected override void OnLoseListener()
        {
            characterHealth.OnDeath.RemoveListener(MakeDecision);
        }
    }
}