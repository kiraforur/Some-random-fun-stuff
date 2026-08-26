using UnityEngine;
using Player;

namespace State
{
    public class AttackState : PlayerBaseState
    {
        public AttackState(PlayerController player) : base(player) { }

        public override void LogicUpdate() { }

        public override void PhysicsUpdate()
        {         
        }

        private void HandleAttackFinished()
        {
            Debug.Log("Attack finished!");
        }

        public override void Enter()
        {
            player.Combat.OnAttackFinished += HandleAttackFinished;

            player.Combat.PerformAttack();
            
        }

        public override void Exit()
        {
            player.Combat.OnAttackFinished -= HandleAttackFinished;
        }

    }
}
