using UnityEngine;
using Core;

namespace Systems 
{
    public class Hurtbox : MonoBehaviour
    {

        private IDamageable owner;

        private void Awake()
        {
            if (owner == null)
                owner = GetComponentInParent<IDamageable>();
        }

        public void TakeDamage(int damage) 
        {
            owner?.TakeDamage(damage);
        }
    }

}
