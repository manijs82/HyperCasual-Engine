using System;
using System.Collections.Generic;
using System.Linq;
using HyperCasual_Engine.Abilities;
using UnityEditor;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class Character : MonoBehaviour
    {
        public List<Ability> abilities;
        public GameObject characterModel;
        public Animator characterAnimator;

        private InputManager _inputManager;
        private Ability[] _frequentUseAbilities;

        public InputManager InputManager => _inputManager;
        public MovementAbility Movement { get; private set; }


        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
            if(_inputManager == null)
                Debug.LogError("Could not find InputManager. Add the InputManager Script to you scene");
            Movement = GetComponent<MovementAbility>();
            
            _frequentUseAbilities = abilities.Where(a => a.UseInUpdate).ToArray();
            InitAbilities();
        }

        private void InitAbilities()
        {
            foreach (var ability in abilities)
            {
                ability.Init();
            }
        }

        private void Update()
        {
            foreach (var ability in _frequentUseAbilities)
            {
                ability.Use();
            }            
        }

        public void CreateAndAddAbility<T>() where T : Ability
        {
            var ability = gameObject.AddComponent<T>();
            AddAbility(ability);
        }

        public void AddAbility(Ability ability)
        {
            abilities.Add(ability);
            ability.Init();
        }
        
        public void CreateAndAddAbilityWithUndo(Type abilityType)
        {
            if(!typeof(Ability).IsAssignableFrom(abilityType)) return;
            var ability = Undo.AddComponent(gameObject, abilityType) as Ability;
            AddAbilityWithUndo(ability);
        }

        public void AddAbilityWithUndo(Ability ability)
        {
            Undo.RecordObject(this, "Edit Character");
            abilities.Add(ability);
            ability.Init();
        }
        
        public void RemoveAndDestroyAbilityWithUndo(Ability ability)
        {
            RemoveAbilityWithUndo(ability);
            Undo.DestroyObjectImmediate(ability);
        }
        
        public void RemoveAbility(Ability ability) =>
            abilities.Remove(ability);
        
        public void RemoveAbilityWithUndo(Ability ability)
        { 
            Undo.RecordObject(this, "Edit Character");
            abilities.Remove(ability);
        }

        public bool HasAbility<T>() where T : Ability => 
            abilities.Any(a => a.GetType() == typeof(T));

        public Ability GetAbility<T>() where T : Ability => 
            abilities.FirstOrDefault(a => a.GetType() == typeof(T));
        
        public Ability[] GetAbilities<T>() where T : Ability => 
            abilities.Where(a => a.GetType() == typeof(T)).ToArray();
    }
}