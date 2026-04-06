using UnityEngine;
using Core;
using Player;

namespace Command
{
    public class JumpCommand : ICommand
    {
        private readonly PlayerMovement2_5D movement;

        public JumpCommand(PlayerMovement2_5D movement)
        {
            this.movement = movement;
        }

        public void Execute()
        {
            movement.Jump();
        }
    }
}