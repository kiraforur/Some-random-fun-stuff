using UnityEngine;
using Core;
using Player;

namespace Command
{
    public class JumpCommand : ICommand
    {
        private readonly PlayerMovement movement;

        public JumpCommand(PlayerMovement movement)
        {
            this.movement = movement;
        }

        public void Execute()
        {
            movement.ApplyJump();
        }
    }
}