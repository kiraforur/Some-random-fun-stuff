using UnityEngine;
using Utils;

namespace Buttons
{
    public class MoveButton : BaseGameButton
    {
        protected override void ExecuteLogic()
        {
            Debug.Log("Chosen to move to selected Location");
        }
    }
}

