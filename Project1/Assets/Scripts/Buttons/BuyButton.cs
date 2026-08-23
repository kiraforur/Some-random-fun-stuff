using UnityEngine;
using Utils;

namespace Buttons
{
    public class BuyButton : BaseGameButton
    {
        protected override void ExecuteLogic()
        {
            Debug.Log("Chosen to buy an item");
        }
    }
}
