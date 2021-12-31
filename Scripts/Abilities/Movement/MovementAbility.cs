namespace HyperCasual_Engine.Abilities
{
    public class MovementAbility : AbilityScriptableObjectData
    {
        public override void Use()
        {
            if(UsageAuthorized)
                Move();
        }

        protected virtual void Move()
        {
        }
    }
}