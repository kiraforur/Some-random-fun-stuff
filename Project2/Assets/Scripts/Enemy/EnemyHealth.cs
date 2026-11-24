using Core;
using Systems;
using UI;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        private Health _health;

        private void Awake()
        {
            _health = new Health(50);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        void Die()
        {
            Debug.Log("Enemy Is Dead!");
            _health.OnDied -= Die;
        }
    }
}

