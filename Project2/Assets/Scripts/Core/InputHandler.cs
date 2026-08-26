using Command;
using Input;
using Player;
using State;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace Core 
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        private PlayerInputActions inputActions;

        public PlayerInputActions InputActions => inputActions;

        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            
            inputActions?.Enable();
            inputActions.Player.Move.started += OnMoveStarted;
            inputActions.Player.Jump.performed += OnJumpPerformed;
            inputActions.Player.Super.performed += OnSuperPerformed;
            inputActions.Player.Attack.performed += OnAttackPerformed;
        }

        private void OnDisable()
        {
            inputActions.Player.Move.started -= OnMoveStarted;
            inputActions.Player.Jump.performed -= OnJumpPerformed;
            inputActions.Player.Super.performed -= OnSuperPerformed;
            inputActions.Player.Attack.performed -= OnAttackPerformed;
            inputActions?.Disable();
        }

        private void OnJumpPerformed(InputAction.CallbackContext ctx)
        {
           Execute(new JumpCommand(player.Movement));
        }

        private void OnSuperPerformed(InputAction.CallbackContext ctx)
        {
           Execute(new SuperCommand(player.SuperMove));
        }

        private void OnAttackPerformed(InputAction.CallbackContext ctx)
        {
            Execute(new AttackCommand());
        }

        private void OnMoveStarted(InputAction.CallbackContext ctx)
        {
            if (player != null)
            {
                var locomotionState = player.GetCurrentState() as LocomotionState;
                locomotionState?.OnMovePerformed(ctx.ReadValue<Vector2>().x);
            }
        }

        private void Execute(ICommand command)
        {
            player.HandleCommand(command);
        }
    }
}

