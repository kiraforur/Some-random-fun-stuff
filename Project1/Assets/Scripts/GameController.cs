using Buttons;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public List<Player> players;
    public TurnManager turnManager;

    private int currRound = 1;
    private BoardState boardState;

    [SerializeField] private LocationSelectionController locationSelectionController;

    [SerializeField] private Button nextTurnButton;
    [SerializeField] private MoveButton moveButton;
    private void Start()
    {
        CreatePlayersWithRandomRoles();

        turnManager = new TurnManager(players);

        moveButton.OnButtonClicked += HandleGameButton;

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
        player.StartTurn(currRound);

        Debug.Log(
        $"This is Player {player.Id}'s turn. " +
        $"Actions: {player.RemainingActions}");

        MakeAction();
    }

    public void MakeAction()
    {
        Debug.Log($"Player {turnManager.Current.Id} makes an action.");

        nextTurnButton.gameObject.SetActive(true);
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

        if(currRound > 3)
        {
            Debug.Log("End game");
            return;
        }

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

    public void OnNextTurnButtonClick()
    {
        nextTurnButton.gameObject.SetActive(false);

        EndTurn();
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

    public void TryMoveCurrentPlayer()
    {
        Player player = turnManager.Current;

        LocationView selectedView = locationSelectionController.SelectedLocation;

        if (selectedView == null)
        {
            Debug.Log("Сначала выберите локацию.");
            return;
        }

        Location destination = boardState.GetLocation(selectedView.LocationId);

        if (player.CurrentLocation == destination)
        {
            Debug.Log(
                $"Player {player.Id} already is in {destination.Name}.");
            return;
        }

        if (!player.TrySpendAction())
        {
            Debug.Log(
                $"Player {player.Id} has no actions remaining.");
            return;
        }

        player.MoveTo(destination);

        Debug.Log(
            $"Player {player.Id} moved to {destination.Name}. " +
            $"Actions left: {player.RemainingActions}");
    }

    private void HandleGameButton(ActionType actionType)
    {
        switch (actionType)
        {
            case ActionType.Move:
                TryMoveCurrentPlayer();
                break;
        }
    }

    private void OnDestroy()
    {
        if (moveButton != null)
        {
            moveButton.OnButtonClicked -= HandleGameButton;
        }
    }
}


