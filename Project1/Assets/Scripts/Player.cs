using UnityEngine;

public class Player
{
    public int Id { get; set; }
    PlayerStats stats;
    int gold;

    public Player(int id, RoleType role) 
    {
        Id = id;
        this.stats = RoleStatsFactory.Create(role);
        gold = 0;
    }
}
