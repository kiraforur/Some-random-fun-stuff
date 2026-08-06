using UnityEngine;

public class TurnDebugPanel : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

#if UNITY_EDITOR

    private void OnGUI()
    {
        if (gameController == null ||
            gameController.turnManager == null ||
            gameController.turnManager.Current == null)
        {
            return;
        }

        GUILayout.BeginArea(
            new Rect(15, 15, 240, 110),
            GUI.skin.box);

        Player currentPlayer =
            gameController.turnManager.Current;

        GUILayout.Label(
            $"Текущий игрок: {currentPlayer.Id}");

        if (GUILayout.Button("Следующий ход"))
        {
            gameController.NextTurn();
        }

        GUILayout.EndArea();
    }

#endif
}
