using System;
using System.Collections.Generic;
using System.Linq;

public class Location
{
    private const int MaxControl = 5;
    private const int OwnershipControl = 3;

    private readonly Dictionary<int, int> controlByPlayer = new();

    private readonly ILocationEffect effect;

    public int Id { get; }
    public string Name { get; }
    public LocationType Type { get; }

    public Location(
        int id,
        string name,
        LocationType type,
        ILocationEffect effect)
    {
        Id = id;
        Name = name;
        Type = type;
        this.effect = effect;
    }

    public int GetControl(int playerId)
    {
        return controlByPlayer.TryGetValue(playerId, out int value)
            ? value
            : 0;
    }

    public void AddControl(int playerId, int amount = 1)
    {
        int current = GetControl(playerId);

        controlByPlayer[playerId] =
            Math.Clamp(current + amount, 0, MaxControl);
    }

    public void RemoveControl(int playerId, int amount = 1)
    {
        int current = GetControl(playerId);

        controlByPlayer[playerId] =
            Math.Clamp(current - amount, 0, MaxControl);
    }

    public int? GetOwnerId()
    {
        var candidates = controlByPlayer
            .Where(x => x.Value >= OwnershipControl)
            .OrderByDescending(x => x.Value)
            .ToList();

        if (candidates.Count == 0)
        {
            return null;
        }

        int highestControl = candidates[0].Value;

        int playersWithSameControl =
            candidates.Count(x => x.Value == highestControl);

        if (playersWithSameControl > 1)
        {
            return null;
        }

        return candidates[0].Key;
    }

    public void ActivateEffect(Player player)
    {
        effect?.Activate(this, player);
    }
}
