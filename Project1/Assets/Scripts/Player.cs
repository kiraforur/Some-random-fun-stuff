using Stats; 
public class Player
{
    public int Id { get; }
    public RoleType Role { get; }

    public PlayerStats Stats { get; }

    public int Gold { get; private set; }

    public int RemainingActions { get; private set; }
    public Location CurrentLocation { get; private set; }
    public int Score { get; private set; }

    public Player(int id, RoleType role)
    {
        Id = id;
        Role = role;
        Stats = RoleStatsFactory.Create(role);

        Gold = 0;
        Score = 0;
    }

    public void AddGold(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        Gold += amount;
    }

    public void AddScore(int amount = 1)
    {
        if (amount <= 0)
        {
            return;
        }

        Score += amount;
    }

    public void MoveTo(Location location)
    {
        CurrentLocation = location;
    }

    public bool TrySpendAction()
    {
        if (RemainingActions <= 0)
        {
            return false;
        }

        RemainingActions--;
        return true;
    }

    public void StartTurn(int act_count) 
    {
        RemainingActions = act_count;
    }

}

