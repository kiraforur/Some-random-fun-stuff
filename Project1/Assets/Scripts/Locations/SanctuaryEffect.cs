using UnityEngine;

public class SanctuaryEffect : ILocationEffect
{
    public void Activate(Location location, Player player) 
    {
        Debug.Log("Sanctuary was activated");
    }
}
