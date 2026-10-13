using Core;
using Player;
using UnityEngine;


namespace State
{
    public class SuperState : PlayerBaseState
    {
        public SuperState(PlayerController player) : base(player) { }
        private void OnSuperAttackFinished()
        {
            player.ChangeState(player.LocomotionState);
        }

        public override void Enter()
        {
            player.SuperMove.OnSuperFinished += OnSuperAttackFinished;

            player.SuperMove.UseSuper();
            player.Animator.Play("Super");
        }

        public override void Exit()
        {
            player.SuperMove.OnSuperFinished -= OnSuperAttackFinished;

        }

        public override void LogicUpdate()
        {
            
        }
        
        public override void PhysicsUpdate()
        {
            
        }

        public override void HandleCommand(ICommand command)
        {
           
        }
    }
}
