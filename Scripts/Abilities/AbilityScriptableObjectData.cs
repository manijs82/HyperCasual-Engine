using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class AbilityScriptableObjectData : Ability
    {
        [HideInInspector] public ScriptableObject scriptableObject;
        [Space] public bool useScriptableObjectData = false;

        public override void Init()
        {
            base.Init();
            if(useScriptableObjectData && scriptableObject != null)
                SetScriptableObjectData();
        }

        protected virtual void SetScriptableObjectData() { }
    }
}