using System.Linq;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] protected bool active = true;
        [SerializeField] protected CharacterState[] blockingCharacterStates;
        
        protected Character Owner;

        public bool IsActive
        {
            get => active;
            set => active = value;
        }
        public virtual bool UseInUpdate => true;
        protected virtual bool UsageAuthorized => active
        && !blockingCharacterStates.Contains(Owner.CurrentState);

        public virtual void Init()
        {
            Owner = GetComponent<Character>();
        }

        public virtual void Use() { }
    }
}