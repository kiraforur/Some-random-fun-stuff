using UnityEngine;

public class GhettoEffect : ILocationEffect
{
    public void Activate(Location location, Player player) 
    {
        Debug.Log("GhettoEffect was activated");
    }
}
