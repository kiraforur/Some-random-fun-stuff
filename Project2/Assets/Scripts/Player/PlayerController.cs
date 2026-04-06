using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement2_5D Movement { get; private set; }
        /*public PlayerCombat Combat { get; private set; }*/
        public SuperMoveController SuperMove { get; private set; }


        private void Awake()
        {
            Movement = GetComponent<PlayerMovement2_5D>();
            /*Combat = GetComponent<PlayerCombat>();*/
            SuperMove = GetComponent<SuperMoveController>();
        }
    }

}