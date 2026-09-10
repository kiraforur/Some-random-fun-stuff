using UnityEngine;

public class MainSquireEffect : ILocationEffect
{
    public void Activate(Location location, Player player)
    {
        Debug.Log("MainSquireEffect was activated");
    }
}
