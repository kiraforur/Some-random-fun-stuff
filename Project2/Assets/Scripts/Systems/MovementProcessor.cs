using UnityEngine;

namespace Systems
{
    public class MovementProcessor
    {
        private readonly MoveData _data;

        public MovementProcessor(MoveData data) => _data = data;

        public Vector3 CalculateVelocity(Vector2 input, bool isRunning, float currYVelocity)
        { 
            float speed = isRunning ? _data.runSpeed : _data.walkSpeed ;
            return new Vector3(input.x * speed, currYVelocity, input.y * speed);
        }

        public float GetJumpVelocity() => _data.jumpForce;

        public float GetDashVelocity() => _data.dashForce;

    }
}
