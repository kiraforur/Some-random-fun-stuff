using UnityEngine;
using Systems;
using System.Collections.Generic;
using System;
using Core;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [Header("Combos")]
        
        [SerializeField] private AttackData[] _groundAttacks;
        private ComboString _comboString;
        private int _facing;
        public AttackData _currentAttack;
        
        //public ComboManager comboManager;
        public event Action OnAttackFinished;
        

        public SuperMoveController superMove;
        private Hitbox hitbox;

        private void Awake()
        {
            //comboManager = new ComboManager();
            _comboString = new ComboString(_groundAttacks);
            hitbox = GetComponent<Hitbox>();
        }

        public void OnAnimationFinished()
        {
            OnAttackFinished?.Invoke();
        }
       
        public AttackData PerformAttack(int facing)
        {
            Debug.Log("ATTACK!");

            _currentAttack = _comboString.GetNextAttack();
            Debug.Log($"{_currentAttack.AnimationName}");
            _facing = facing;

            return _currentAttack;
        }

        public void HitFrame()
        {
            if (_currentAttack != null)
            {   
                hitbox.CheckHit(_currentAttack, _facing);
            }
        }

        public void ClearHash()
        {
            hitbox.ClearHash();
        }
        public void Reset()
        {
            _currentAttack = null;
            _comboString.Reset();
        }

        /*private void Update()
        {
            comboManager.Tick(Time.deltaTime);
            
        }*/
    }
}
