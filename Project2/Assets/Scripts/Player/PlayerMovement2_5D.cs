using UnityEngine;

namespace Player
{
    public class PlayerMovement2_5D : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed = 5f;

        [Header("Jump")]
        public float jumpForce = 5f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public float groundCheckDistance = 0.2f;

        private Vector2 moveInput;
        private Rigidbody rb;
        private bool isGrounded;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        public void SetMovement(Vector2 input)
        {
            moveInput = input;
        }

        public void Jump()
        {
            if (!isGrounded) return;

            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                jumpForce,
                rb.linearVelocity.z
            );
        }

        private void FixedUpdate()
        {
            CheckGround();

            Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

            Vector3 velocity = new Vector3(
                moveDirection.x * moveSpeed,
                rb.linearVelocity.y,
                moveDirection.z * moveSpeed
            );

            rb.linearVelocity = velocity;
        }

        private void CheckGround()
        {
            isGrounded = Physics.CheckSphere(
                groundCheck.position,
                groundCheckDistance,
                groundLayer
            );
        }

        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
            }
        }
    }
}
