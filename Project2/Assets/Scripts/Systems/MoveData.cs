using UnityEngine;

namespace Systems
{
    [CreateAssetMenu(fileName = "MoveData", menuName = "Scriptable Objects/MoveData")]
    public class MoveData : ScriptableObject
    {
        public float walkSpeed = 5f;
        public float runSpeed = 28f;
        public float jumpForce = 7f;
        public float dashForce = 15f;
        public float dashDuration = 0.2f;
    }
}
