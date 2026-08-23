using UnityEngine;

namespace Stats {
    public static class RoleStatsFactory
    {
        public static PlayerStats Create(RoleType role)
        {
            switch (role)
            {
                case RoleType.Lord:
                    return new PlayerStats
                    {
                        Power = 5,
                        Influence = 4,
                        Economics = 3
                    };

                case RoleType.Trader:
                    return new PlayerStats
                    {
                        Power = 3,
                        Influence = 5,
                        Economics = 4
                    };

                case RoleType.Saboteur:
                    return new PlayerStats
                    {
                        Power = 4,
                        Influence = 2,
                        Economics = 5
                    };

                case RoleType.Priest:
                    return new PlayerStats
                    {
                        Power = 2,
                        Influence = 6,
                        Economics = 4
                    };

                case RoleType.Captain:
                    return new PlayerStats
                    {
                        Power = 1,
                        Influence = 3,
                        Economics = 6
                    };

                case RoleType.Sorcerer:
                    return new PlayerStats
                    {
                        Power = 1,
                        Influence = 3,
                        Economics = 6
                    };
                default:
                    return new PlayerStats();
            }
        }
    }
}
