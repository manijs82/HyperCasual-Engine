using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class FallingMovement : MovementAbility
    {
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if(GetComponent<Rigidbody>() == null)
                gameObject.AddComponent<Rigidbody>();
        }
    }
}