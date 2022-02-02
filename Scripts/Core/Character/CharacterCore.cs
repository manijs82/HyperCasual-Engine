using UnityEditor;
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
            RemovePlayerVisuals();
            _visuals = new CharacterVisuals(this, playerVisuals);
            characterModel = _visuals.VisualsGameObject;
            playerAnimator = _visuals.VisualsGameObjectAnimator;
        }
        
        public void RemovePlayerVisuals()
        {
            if (characterModel == null) return;
            
            Undo.DestroyObjectImmediate(characterModel);
            Undo.RecordObject(this, "Removed Character Visuals");
            characterModel = null;
            playerAnimator = null;            
            _visuals = null;
        }
    }
}