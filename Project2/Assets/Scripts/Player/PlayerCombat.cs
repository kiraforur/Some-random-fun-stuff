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
        public event Action<AttackData> OnAttackPerformed;

        public SuperMoveController superMove;
        private Hitbox hitbox;

        private void Awake()
        {
            var combos = BuildCombos();
            comboManager = new ComboManager(combos);

           
        }

        private Dictionary<AttackContext, ComboString> BuildCombos()
        {
            var dict = new Dictionary<AttackContext, ComboString>();

            dict[AttackContext.Ground] = new ComboString(groundAttacks);

            return dict;
        }

        

        private void Update()
        {
            comboManager.Tick(Time.deltaTime);
            
        }
    }
}
