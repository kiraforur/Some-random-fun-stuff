using UnityEngine;
using Systems;
namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] MoveData moveData;
        private MovementProcessor _processor;
        private Rigidbody _rg;
        private BoxCollider _collider;

        private void Awake()
        {
            _rg = GetComponent<Rigidbody>();
            _processor = new MovementProcessor(moveData);
            _collider = GetComponent<BoxCollider>();
        }

        public void ApplyMovement(Vector2 input, bool isRunning)
        {
            _rg.linearVelocity = _processor.CalculateVelocity(input, isRunning, _rg.linearVelocity.y);
        }
        
        public void ApplyJump()
        {
            if (isGrounded())
            {
                _rg.linearVelocity = new Vector3(_rg.linearVelocity.x, _processor.GetJumpVelocity(), _rg.linearVelocity.z);
            }
        }

        private bool isGrounded() {
            float rayLength = (_collider.size.y / 2f) + 0.1f;

            return Physics.Raycast(_collider.bounds.center, Vector3.down, rayLength);
        }
    }
}
