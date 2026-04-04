using UnityEngine;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
    public List<Player> players;
    public TurnManager turnManager;

    private void Start()
    {
        CreatePlayersWithRandomRoles();
        turnManager = new TurnManager(players);

        Debug.Log($"Первый ход: Игрок {turnManager.Current.Id}");
    }

    private void CreatePlayersWithRandomRoles()
    {
        players= new List<Player>();
        List<RoleType> roles =
           new List<RoleType>((RoleType[])Enum.GetValues(typeof(RoleType)));

        for (int i = 0; i < 6; i++)
        {
            players.Add(new Player(i, roles[i]));
        }
    }

    public void NextTurn()
    {
        Player nextPlayer = turnManager.Next();
        Debug.Log($"Ход игрока {nextPlayer.Id}");
    }

    private void Shuffle(List<RoleType> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }
}
