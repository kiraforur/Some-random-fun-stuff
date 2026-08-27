using UnityEngine;
using Systems;
using System.Collections.Generic;
using System;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [Header("Combos")]
        [SerializeField] private AttackData[] _groundAttacks;
        private ComboString _comboString;


        
        public ComboManager comboManager;
        public event Action OnAttackFinished;
        

        public SuperMoveController superMove;
        //private Hitbox hitbox;

        private void Awake()
        {
            comboManager = new ComboManager();
            _comboString = new ComboString(_groundAttacks);
        }

        public void OnAnimationFinished()
        {
            OnAttackFinished?.Invoke();
        }
       
        public AttackData PerformAttack()
        {
            Debug.Log("ATTACK!");

            AttackData attack = _comboString.GetNextAttack();
            Debug.Log($"{attack.AnimationName}");

            return attack;
        }

        public void Reset()
        {
            _comboString.Reset();
        }


        private void Update()
        {
            comboManager.Tick(Time.deltaTime);
            
        }
    }
}
