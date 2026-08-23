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

            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
                    type,
                    null
                );
        }
    }
}
