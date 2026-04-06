using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems
{
    public class ComboString
    {
        [SerializeField] private AttackData[] attacks;
        private readonly float comboTime = 1f;

        private int comboIndex = 0;
        private float timer;

        public ComboString(AttackData[] attacks)
        {
            this.attacks = attacks;
            comboIndex = 0;
        }
        public AttackData GetNextAttack()
        {
            timer = comboTime;

            var attack = attacks[comboIndex];

            comboIndex++;

            if (comboIndex >= attacks.Length)
                Reset();

            return attack;
        }

        
        public void Tick(float deltaTime)
        {
            if (timer <= 0) return;

            timer -= deltaTime;

            if (timer <= 0)
                Reset();
        }

        public void Reset()
        {
            comboIndex = 0;
        }
    }
}

