using UnityEngine;
using Core;
using Player;

namespace Command
{
    public class SuperCommand : ICommand
    {
        private readonly SuperMoveController super;

        public SuperCommand(SuperMoveController super)
        {
            this.super = super;
        }
        public void Execute()
        {
            super.ActivateSuper();
        }
    }
}
