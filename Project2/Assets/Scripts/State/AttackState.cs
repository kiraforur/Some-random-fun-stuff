using UnityEngine;
using Player;
using Core;
using Command;

namespace State
{
    public class AttackState : PlayerBaseState
    {
        private bool _nextAttackRequested = false;
        public AttackState(PlayerController player) : base(player) { }

        public override void LogicUpdate() { }

        public override void PhysicsUpdate()
        {         
        }

        private void HandleAttackFinished()
        {
            if (_nextAttackRequested == true)
            {
                _nextAttackRequested = false;
                
                AttackData data = player.Combat.PerformAttack();
                player.Animator.Play(data.AnimationName);
                player.SuperMove.AddToMeter();
            }
            else
            {
                player.ChangeState(player.LocomotionState);
            }
        }

        public override void Enter()
        {
            _nextAttackRequested = false;
            player.Combat.OnAttackFinished += HandleAttackFinished;
            
            AttackData data = player.Combat.PerformAttack();
            player.Animator.Play(data.AnimationName);
            player.SuperMove.AddToMeter();
        }

        public override void Exit()
        {
            player.Combat.OnAttackFinished -= HandleAttackFinished;

            player.Combat.Reset();
        }

        public override void HandleCommand(ICommand command)
        {
            if(command is AttackCommand)
            {
                _nextAttackRequested = true;
            } else
            {
                _nextAttackRequested = false;
            }
        }

    }
}
