using Systems;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] MoveData moveData;
        private MovementProcessor _processor;
        private Rigidbody _rg;
        private BoxCollider _collider;
        private int _facing;

        public int Facing => _facing;

        private void Awake()
        {
            _rg = GetComponent<Rigidbody>();
            _processor = new MovementProcessor(moveData);
            _collider = GetComponent<BoxCollider>();
            _facing = 1;
        }

        public void ApplyMovement(Vector2 input, bool isRunning)
        {
            _rg.linearVelocity = _processor.CalculateVelocity(input, isRunning, _rg.linearVelocity.y);
        }
        
        public void ApplyJump()
        {
            if (IsGrounded())
            {
                _rg.linearVelocity = new Vector3(_rg.linearVelocity.x, _processor.GetJumpVelocity(), _rg.linearVelocity.z);
            }
        }

        public bool IsGrounded() {
            float rayLength = (_collider.size.y / 2f) + 0.1f;

            return Physics.Raycast(_collider.bounds.center, Vector3.down, rayLength);
        }

        public void UpdateFacing(float inputX) { 
            if(inputX > 0) { _facing = 1; }
            else if(inputX < 0) { _facing = -1; }
        }
    }
}
