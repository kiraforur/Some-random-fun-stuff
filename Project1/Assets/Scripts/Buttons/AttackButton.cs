using UnityEngine;
using Utils;

namespace Buttons
{
    public class AttackButton : BaseGameButton
    {
        protected override void ExecuteLogic()
        {
            Debug.Log("Chosen the attack");
        }
    }
}
