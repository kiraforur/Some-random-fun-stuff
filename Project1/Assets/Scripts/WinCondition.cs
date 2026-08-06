using UnityEngine;

public class WinCondition
{
    private readonly int scoreToWin;

    public WinCondition(int scoreToWin)
    {
        this.scoreToWin = scoreToWin;
    }

    public bool IsWinner(Player player) 
    {
        return player.Score >= scoreToWin;
    }
    
}
