using System;
using System.Collections.Generic;

public class BoardState
{
    private readonly Dictionary<int, Location> locations = new();

    public IEnumerable<Location> Locations => locations.Values;

    public void AddLocation(Location location)
    {
        locations.Add(location.Id, location);
    }

    public Location GetLocation(int id)
    {
        if (!locations.TryGetValue(id, out Location location))
        {
            throw new ArgumentException(
                $"Location with id {id} does not exist.");
        }

        return location;
    }
}
