using UnityEngine;

namespace HyperCasual_Engine
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] protected bool active = true;
        
        protected Character Owner;

        public bool IsActive
        {
            get => active;
            set => active = value;
        }
        public virtual bool UseInUpdate => true;
        protected virtual bool UsageAuthorized => active;

        public virtual void Init()
        {
            Owner = GetComponent<Character>();
        }

        public virtual void Use() { }
    }
}