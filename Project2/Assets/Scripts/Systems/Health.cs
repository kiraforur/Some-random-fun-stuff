using UnityEngine;
using System;

namespace Systems
{
    public class Health
    {
        public float CurrHealth { get; private set; }
        public float MaxHealth { get; private set; }

        public event Action<float> OnHealthChanged;
        public event Action OnDied;
        public Health(float max)

        {
            MaxHealth = max;
            CurrHealth = MaxHealth;
            
        }

        public void TakeDamage(float damage) 
        {
            CurrHealth = Mathf.Max(CurrHealth - damage, 0);
            OnHealthChanged?.Invoke((float)CurrHealth / MaxHealth);

            if (CurrHealth == 0)
                OnDied?.Invoke();
        }

        public void IncreaseHealth(float damage)
        {
            CurrHealth = Mathf.Min(CurrHealth + damage, MaxHealth);
            OnHealthChanged?.Invoke((float)CurrHealth / MaxHealth);
        }


    }
}

