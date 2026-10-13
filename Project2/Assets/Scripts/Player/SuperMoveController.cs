using UnityEngine;
using Systems;
using System;

namespace Player 
{
    public class SuperMoveController : MonoBehaviour
    {
        private SuperMeter meter;

        [SerializeField] private int maxSuper;
        public int damage;

        
        /*public Animator animator;
        public GameObject superEffectPrefab;
        public AudioSource superSound;*/
        private Hitbox hitbox;
        public event Action OnSuperFinished;

        void Awake()
        {
            meter = new SuperMeter(maxSuper);
            hitbox = GetComponent<Hitbox>();
        }
        
        public void AddToMeter()
        {
            meter.Add(10);
        }

        public bool CanActivateSuper() 
        {
            return meter.Max == meter.CurrMeter;
        }

        public void UseSuper()
        {
            meter.Reset();
        }

        public void OnAnimationFinished()
        {
            OnSuperFinished?.Invoke();
        }

        public SuperMeter GetMeter() => meter;
    }
}

    