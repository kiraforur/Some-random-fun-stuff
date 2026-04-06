using UnityEngine;
using UnityEngine.InputSystem;
using Command;
using Input;
using Player;

namespace Core 
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        private PlayerInputActions inputActions;
        void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        void OnEnable()
        {
            inputActions.Enable();

            /*inputActions.Player.Attack.performed += _ =>
                Execute(new AttackCommand(player.Combat));*/

            inputActions.Player.Jump.performed += _ =>
                Execute(new JumpCommand(player.Movement));

            inputActions.Player.Super.performed += _ =>
               Execute(new SuperCommand(player.SuperMove));
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
        
        void Update()
        {
            Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();
            Execute(new MoveCommand(player.Movement, move));
        }

        private void Execute(ICommand command)
        {
            command.Execute();
        }
    }
}

