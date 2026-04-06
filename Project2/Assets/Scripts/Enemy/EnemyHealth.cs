using UnityEngine;
using Core;
using Systems;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        private Health health;
        public void TakeDamage(int damage)
        {
            health.TakeDamage(damage);
        }
    }
}

