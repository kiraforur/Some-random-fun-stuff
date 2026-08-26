using Core;
using Player;
using UnityEngine;

namespace State
{
    public abstract class PlayerBaseState : IState
    {
        protected PlayerController player;
        protected InputHandler input;

        public PlayerBaseState(PlayerController player)
        {   
            this.player = player;
            this.input = player.GetComponent<InputHandler>();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }

        public virtual void HandleCommand(ICommand command) { command.Execute(); }
      
    }
}
