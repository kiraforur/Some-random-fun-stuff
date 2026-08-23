using UnityEngine;
using Utils;

namespace Buttons
{
    public class NextTurnButton : BaseGameButton
    {
        protected override void ExecuteLogic()
        {
            Debug.Log("Gave up his action");
        }
    }
}
