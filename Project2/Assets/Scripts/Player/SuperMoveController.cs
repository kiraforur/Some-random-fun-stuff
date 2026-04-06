using UnityEngine;
using Systems;

namespace Player 
{
    public class SuperMoveController : MonoBehaviour
    {
        private SuperMeter meter;

        [SerializeField] private int maxSuper = 100;
        public int damage;
        
        /*public Animator animator;
        public GameObject superEffectPrefab;
        public AudioSource superSound;*/
        private Hitbox hitbox;

        void Awake()
        {
            meter = new SuperMeter(maxSuper);
            hitbox = GetComponent<Hitbox>();
        }
        
        public void AddToMeter()
        {
            meter.Add(10);
        }

        public void ActivateSuper() 
        {
            if (!meter.Activate())
                return;

            /*animator.SetTrigger("Super");*/
           
            /*superSound.Play();*/
            

            hitbox.CheckHit(damage);
        }

        public SuperMeter GetMeter() => meter;
    }
}

    