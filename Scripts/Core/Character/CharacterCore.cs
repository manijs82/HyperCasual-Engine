using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class CharacterCore : Character
    {
        [Header("Character Creator")]
        public PlayerVisualsType characterVisuals;
        public GameObject visualsPrefab;

        private CharacterVisuals _visuals;

        public void CreatePlayerVisuals()
        {
            RemovePlayerVisuals();
            _visuals = new CharacterVisuals(this, characterVisuals);
            characterModel = _visuals.VisualsGameObject;
            characterAnimator = _visuals.VisualsGameObjectAnimator;
        }
        
        public void RemovePlayerVisuals()
        {
            if (characterModel == null) return;
            
            Undo.DestroyObjectImmediate(characterModel);
            Undo.RecordObject(this, "Removed Character Visuals");
            characterModel = null;
            characterAnimator = null;            
            _visuals = null;
        }
    }
}