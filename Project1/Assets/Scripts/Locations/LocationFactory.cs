using UnityEngine;

public static class LocationFactory
{
    public static Location Create(
        int id,
        LocationType type)
    {
        switch (type)
        {
            case LocationType.Port:
                return new Location(
                    id,
                    "Port",
                    type,
                    new PortEffect()
                );

            case LocationType.Market:
                return new Location(
                    id,
                    "Market",
                    type,
                    new MarketEffect()
                );

            case LocationType.Citadel:
                return new Location(
                    id,
                    "Citadel",
                    type,
                    new CitadelEffect()
                );

            case LocationType.MainSquire:
                return new Location(
                    id, "MainSquire", type, new MainSquireEffect());

            case LocationType.Ghetto:
                return new Location(
                    id, "Ghetto", type, new GhettoEffect());

            case LocationType.Sanctuary:
                return new Location(
                    id, "Sanctuary", type, new SanctuaryEffect());

            case LocationType.NobleQuarter:
                return new Location(
                    id, "NobleQuarter", type, new NobleQuarterEffect());

            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
                    type,
                    null
                );
        }
    }
}
