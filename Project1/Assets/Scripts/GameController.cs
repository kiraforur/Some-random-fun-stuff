using UnityEngine;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
    public List<Player> players;
    public TurnManager turnManager;
    private int currRound = 1;

    private void Start()
    {
        CreatePlayersWithRandomRoles();
        turnManager = new TurnManager(players);
        StartGame();
    }

    private void CreatePlayersWithRandomRoles()
    {
        players= new List<Player>();
        List<RoleType> roles =
           new List<RoleType>((RoleType[])Enum.GetValues(typeof(RoleType)));

        Shuffle(roles);
        for (int i = 0; i < 6; i++)
        {
            players.Add(new Player(i, roles[i]));
        }
    }

    public void StartGame()
    {
        Debug.Log("=== GAME START ===");

        foreach(Player player in players)
        {
            Debug.Log($"Player {player.Id} | Role: {player.Role}");
        }

        Debug.Log($"=== ROUND {currRound} START ===");
        NextTurn();
    }
    public void NextTurn()
    {
        Player player = turnManager.Current;
        Debug.Log($"This is {player.Id}'s turn.");
        MakeAction(player);
    }
    
    public void MakeAction(Player player)
    {
        Debug.Log($"{player.Id}, what do you want to do?");

        EndTurn();
    }

    public void EndTurn()
    {
        Debug.Log("The end of the turn");

        bool isRoundOver = turnManager.Next();
        if(isRoundOver) {
            EndRound();
        } else {
            NextTurn();
        }
    }

    public void EndRound()
    {
        Debug.Log($"The end of the {currRound} round");
            currRound++;
        Debug.Log($"=== ROUND {currRound} START ==="
        NextTurn();
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
