using UnityEngine;

public class TurnCameraBridge : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private PlayerCameraController cameraController;

    private int lastPlayerId = -1;

    private void LateUpdate()
    {
        if (gameController == null ||
            cameraController == null ||
            gameController.turnManager == null ||
            gameController.turnManager.Current == null)
        {
            return;
        }

        int currentPlayerId =
            gameController.turnManager.Current.Id;

        if (currentPlayerId == lastPlayerId)
        {
            return;
        }

        bool isFirstCameraPosition = lastPlayerId < 0;

        lastPlayerId = currentPlayerId;

        cameraController.ShowPlayer(
            currentPlayerId,
            isFirstCameraPosition);
    }
}
