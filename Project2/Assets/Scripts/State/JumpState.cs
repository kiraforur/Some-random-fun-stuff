using Player;
using UnityEngine;

namespace State
{
    public class JumpState : PlayerBaseState
    {
        private bool _hasLeftTheGround;
        public JumpState(PlayerController player) : base(player) { }
        private Vector2 _move;
        public override void Enter()
        {
            player.Movement.ApplyJump();
            _hasLeftTheGround = false;
            player.Animator.Play("Jump");
        }

        public override void Exit()
        {
        }

        public override void LogicUpdate()
        {
            _move = player.Input.MoveInput;
            if (player.Movement.IsGrounded() == false) { _hasLeftTheGround = true; }
            if(player.Movement.IsGrounded() == true && _hasLeftTheGround)
            {
                player.ChangeState(new LocomotionState(player));
            }

            
        }

        public override void PhysicsUpdate()
        {
            player.Movement.ApplyMovement(_move, false);
        }
    }
}

