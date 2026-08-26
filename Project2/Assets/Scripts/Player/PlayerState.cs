using UnityEngine;
using Core;

namespace Player
{
    public abstract class BasePlayer : IState 
    {
        protected PlayerController _player;
        public BasePlayer(PlayerController player) => _player = player;

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public abstract void HandleCommand(ICommand command);
    }
}