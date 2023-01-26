using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class Movement2D : MovementAbility
    {
        Rigidbody2D body;

        float horizontal;
        float vertical;
        float moveLimiter = 0.7f;

        void Start ()
        {
            body = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            horizontal = Owner.InputManager.horizontal;
            vertical = Owner.InputManager.vertical;
        }

        void FixedUpdate()
        {
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal * initialSpeed, vertical * initialSpeed);
        }
    }
}