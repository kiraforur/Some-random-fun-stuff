using UnityEngine;
using System.Collections.Generic;
using System;


public class GameController : MonoBehaviour
{
    public List<Player> players;
    public TurnManager turnManager;

    private int currRound = 1;
    private BoardState boardState;

    private void Start()
    {
        CreatePlayersWithRandomRoles();

        turnManager = new TurnManager(players);

        StartGame();
    }

    private void CreatePlayersWithRandomRoles()
    {
        players = new List<Player>();

        List<RoleType> roles =
            new List<RoleType>(
                (RoleType[])Enum.GetValues(typeof(RoleType)));

        Shuffle(roles);

        for (int i = 0; i < 6; i++)
        {
            players.Add(new Player(i, roles[i]));
        }
    }

    public void StartGame()
    {
        Debug.Log("=== GAME START ===");

        foreach (Player player in players)
        {
            Debug.Log(
                $"Player {player.Id} | Role: {player.Role}");
        }

        Debug.Log($"=== ROUND {currRound} START ===");

        /*Location port =
            LocationFactory.Create(
                0,
                LocationType.Port
        );

        Location market =
            LocationFactory.Create(
                1,
                LocationType.Market
            );

        Location citadel =
            LocationFactory.Create(
                2,
                LocationType.Citadel
            ); */ // then move this part into container
        boardState = CreateBoard();

        StartTurn();
    }

    private void StartTurn()
    {
        Player player = turnManager.Current;

        Debug.Log($"This is Player {player.Id}'s turn.");
    }

    public void EndTurn()
    {
        Debug.Log(
            $"Player {turnManager.Current.Id} ended the turn.");

        bool isRoundOver = turnManager.Next();

        if (isRoundOver)
        {
            EndRound();
            return;
        }

        StartTurn();
    }

    private void EndRound()
    {
        Debug.Log($"=== ROUND {currRound} END ===");

        currRound++;

        Debug.Log($"=== ROUND {currRound} START ===");

        StartTurn();
    }

    private void Shuffle(List<RoleType> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex =
                UnityEngine.Random.Range(i, list.Count);

            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }

    private BoardState CreateBoard()
    {
        BoardState board = new BoardState();

        board.AddLocation(
            LocationFactory.Create(
                0,
                LocationType.Port));

        board.AddLocation(
            LocationFactory.Create(
                1,
                LocationType.Market));

        board.AddLocation(
            LocationFactory.Create(
                2,
                LocationType.Citadel));

        return board;
    }
}


