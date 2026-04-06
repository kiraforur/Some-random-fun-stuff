using UnityEngine;
using Core;
using Player;

namespace Command
{
    public class MoveCommand : ICommand
    {
        private readonly PlayerMovement2_5D movement;
        private readonly Vector2 input;

        public MoveCommand(PlayerMovement2_5D movement, Vector2 input)
        {
            this.movement = movement;
            this.input = input;
        }
        public void Execute()
        {
            movement.SetMovement(input);
        }
    }
}