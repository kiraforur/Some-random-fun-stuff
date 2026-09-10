using UnityEngine;

public class NobleQuarterEffect : ILocationEffect
{
    public void Activate(Location location , Player player) 
    {
        Debug.Log("NobleQurterEffect was activated");
    }
}
