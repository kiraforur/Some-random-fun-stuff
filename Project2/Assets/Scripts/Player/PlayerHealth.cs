using UnityEngine;
using UI;
using Core;
using Systems;


namespace Player 
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        private readonly float maxHealth = 100;
        private Health health;
        
        [SerializeField] private ComboManager comboManager;
        

        void Awake()
        {
            health = new Health(maxHealth);

            health.OnDied += Die;
        }

        public void TakeDamage(int amount)
        {
            health.TakeDamage((float) amount);
            
            comboManager?.ResetCombo();
        }

        public void IncreaseHealth(float amount)
        {
            health.IncreaseHealth(amount);
        }

        public Health GetHealth() => health;

        void Die()
        {
            Debug.Log("You Are Dead!");
            health.OnDied -= Die;
        }
    }
}

