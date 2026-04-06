using UnityEngine;
using Core;
using Player;

namespace Command
{
    public class AttackCommand : ICommand
    { 
        private readonly PlayerCombat combat;
        public AttackCommand(PlayerCombat combat)
        {
            this.combat = combat;
        }

        public void Execute()
        {
            /*combat.Attack();*/
        }
    }
}