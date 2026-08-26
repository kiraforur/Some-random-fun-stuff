using UnityEngine;
using Systems;
using System.Collections.Generic;
using System;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [Header("Combos")]
        [SerializeField] private AttackData[] groundAttacks;
        [SerializeField] private AttackData airAttack;


        
        public ComboManager comboManager;
        public event Action OnAttackFinished;
        

        public SuperMoveController superMove;
        private Hitbox hitbox;

        private void Awake()
        {
            comboManager = new ComboManager();
        }

        public void OnAnimationFinished()
        {
            OnAttackFinished?.Invoke();
        }
       
        public void PerformAttack()
        {
            Debug.Log("ATTACK!");
        }
        

        private void Update()
        {
            comboManager.Tick(Time.deltaTime);
            
        }
    }
}
