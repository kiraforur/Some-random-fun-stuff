using System.Collections.Generic;
using UnityEngine;

namespace Systems 
{
    public class Hitbox : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        private readonly HashSet<Hurtbox> damageables = new HashSet<Hurtbox>();
        private Vector3 _lastCenter, _lastSize;
        
        public void ClearHash()
        {
            damageables.Clear();
        }

        public void CheckHit(AttackData attackData, int facing)
        {

            
            Vector3 center = transform.position + new Vector3(attackData.HitOffset.x * facing, attackData.HitOffset.y, attackData.HitOffset.z);
            _lastCenter = center;
            _lastSize = attackData.HitSize;
            Collider[] colliders = Physics.OverlapBox(center, attackData.HitSize / 2, Quaternion.identity ,_layerMask);

            Debug.Log(colliders.Length);

            foreach(var collider in colliders)
            {
                Hurtbox hit = collider.GetComponent<Hurtbox>();

                if(hit != null && !(damageables.Contains(hit)))
                {
                    damageables.Add(hit);
                    hit.TakeDamage(attackData.Damage);
                    Debug.Log(hit.name);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_lastCenter, _lastSize);
        }
    }

}
