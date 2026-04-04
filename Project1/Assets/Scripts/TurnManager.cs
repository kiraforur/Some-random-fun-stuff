using UnityEngine;
using System.Collections.Generic;
public class TurnManager
{
    private readonly List<Player> players;
    private int currentIndex = 0;

    public TurnManager(List<Player> players)
    {
        this.players = players;
    }

    public Player Current => players[currentIndex];

    public Player Next()
    {
        currentIndex = (currentIndex + 1) % players.Count;
        return Current;
    }
}
