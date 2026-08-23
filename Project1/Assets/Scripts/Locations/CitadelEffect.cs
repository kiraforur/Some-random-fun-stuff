using UnityEngine;

public class CitadelEffect : ILocationEffect
{
    public void Activate(
        Location location,
        Player player)
    {
        Debug.Log(
            $"Player {player.Id} used Citadel."
        );
    }
}
