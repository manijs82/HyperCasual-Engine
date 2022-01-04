using UnityEngine;

namespace HyperCasual_Engine
{
    public class CharacterCore : Character
    {
        [Header("Player Parameters")] 
        public GameObject playerModel;
        public Animator playerAnimator;
        
        [Header("Player Creator")]
        public PlayerVisualsType playerVisuals;

        private CharacterVisuals _visuals;

        public void CreatePlayerVisuals()
        {
            _visuals = new CharacterVisuals(this, playerVisuals);
            playerModel = _visuals.VisualsGameObject;
        }
    }
}