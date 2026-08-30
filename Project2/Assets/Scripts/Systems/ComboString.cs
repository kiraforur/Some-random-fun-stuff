using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems
{
    public class ComboString
    {
        private AttackData[] attacks;
        private readonly float comboTime = 1f;

        private int _comboIndex;
        private float timer;

        public ComboString(AttackData[] attacks)
        {
            this.attacks = attacks;
            _comboIndex = 0;
        }
        public AttackData GetNextAttack()
        {
            timer = comboTime;

            AttackData attack = attacks[_comboIndex];

            _comboIndex++;

            if (_comboIndex >= attacks.Length)
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
            _comboIndex = 0;
        }
    }
}

