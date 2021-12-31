using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class WeaponHandler : Ability
    {
        public Weapon initialWeapon;
        public Transform weaponAttachment;

        private Weapon _currentWeapon;
        
        public override void Init()
        {
            base.Init();
            _currentWeapon = initialWeapon.Spawn(this);
            
            Owner.InputManager.AddListenerToMouseClick(_currentWeapon.inputId, UseWeapon);
        }

        private void UseWeapon()
        {
            if(!UsageAuthorized) return;
            
            _currentWeapon.Use();
        }
        
        private void OnDisable()
        {
            Owner.InputManager.RemoveListenerToMouseClick(_currentWeapon.inputId, UseWeapon);
        }
        
    }
}