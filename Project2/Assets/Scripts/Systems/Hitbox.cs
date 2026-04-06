using UnityEngine;

namespace Systems 
{
    public class Hitbox : MonoBehaviour
    {

        private readonly int radius;
        [SerializeField] private LayerMask layerMask;

        public void CheckHit(int damage)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);

            foreach(var collider in colliders)
            {
                Hurtbox hit = collider.GetComponent<Hurtbox>();

                if(hit != null)
                {
                    hit.TakeDamage(damage);
                }
            }
        }
    }

}
