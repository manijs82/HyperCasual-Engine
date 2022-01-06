using UnityEngine;

namespace HyperCasual_Engine
{
    public class CharacterCore : Character
    {
        [Header("Player Creator")]
        public PlayerVisualsType playerVisuals;
        public GameObject playerModel;

        private CharacterVisuals _visuals;

        public void CreatePlayerVisuals()
        {
            _visuals = new CharacterVisuals(this, playerVisuals);
            characterModel = _visuals.VisualsGameObject;
            playerAnimator = _visuals.VisualsGameObjectAnimator;
        }
    }
}