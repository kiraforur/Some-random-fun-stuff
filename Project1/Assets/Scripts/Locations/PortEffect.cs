using UnityEngine;


public class PortEffect : ILocationEffect
{
    public void Activate(
        Location location,
        Player player)
    {
        Debug.Log(
            $"Player {player.Id} used Port."
        );

    }
}
