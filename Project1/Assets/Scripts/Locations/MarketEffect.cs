using UnityEngine;

public class MarketEffect : ILocationEffect
{
    public void Activate(
        Location location,
        Player player)
    {
        Debug.Log(
            $"Player {player.Id} used Market."
        );
    }
}
