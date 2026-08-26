using Player;
using Command;
using UnityEngine;
using UnityEngine.InputSystem;
using Core;

namespace State
{
    class LocomotionState : PlayerBaseState
    {
        private bool _isRunning = false;
        private Vector2 _moveInput;

        private float _lastTapTime = 0f;
        private float _tapDelayThreshold = 0.25f;
        private int _lastInputX = 0;

        public LocomotionState(PlayerController player) : base(player) { }

        public override void Enter() {
        }

        public override void Exit() { 
        }

        public override void LogicUpdate() {
            _moveInput = player.Input.InputActions.Player.Move.ReadValue<Vector2>();

            
            /*if (_moveInput == Vector2.zero)
            {
                _isRunning = false;
                _lastInputX = 0f;
            }
            else if (!_isRunning)
            {
                
                if (Mathf.Abs(_moveInput.x) > 0.1f && Sign(_moveInput.x) != Sign(_lastInputX))
                {
                    _isRunning = false;
                }
            }*/
        }

        private int Sign(float value)
        {
            if (value > 0.1f) return 1;
            if (value < -0.1f) return -1;
            return 0;
        }
        public override void PhysicsUpdate()
        {
            player.Movement.ApplyMovement(_moveInput, _isRunning);
        }

        public void OnMovePerformed(float inputX)
        {

            int currInput = Sign(inputX);
            
            if((currInput == _lastInputX) && ((Time.time - _lastTapTime) <= _tapDelayThreshold)) 
            {
                _isRunning = true;
            }
            else
            {
                _isRunning = false;
                
            }

            _lastInputX = currInput;
            _lastTapTime = Time.time;
        }


        public override void HandleCommand(ICommand command)
        {
            if (command is AttackCommand)
            {
                player.ChangeState(new AttackState(player));
                return;
            } else
            {
                command.Execute();
            }
        }
    }   
}
