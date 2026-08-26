using UnityEngine;

namespace Core
{
    public interface IState
    {
        void Enter();
        void Exit();
        void HandleCommand(ICommand command);
        void LogicUpdate();

        void PhysicsUpdate();
    }
}