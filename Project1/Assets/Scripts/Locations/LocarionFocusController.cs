using UnityEngine;

public class LocationFocusController : MonoBehaviour
{
    [SerializeField]
    private LocationSelectionController selectionController;

    [SerializeField]
    private PlayerCameraController cameraController;

    [SerializeField]
    private LocationPanelController panelController;

    private void Start()
    {
        selectionController.LocationSelected += OnLocationSelected;
    }

    private void OnDestroy()
    {
        if (selectionController != null)
        {
            selectionController.LocationSelected -= OnLocationSelected;
        }
    }

    private void OnLocationSelected(LocationView location)
    {
        Debug.Log($"[3] Focus received: {location.LocationName}");
        if (location.CameraPoint != null)
        {
            Debug.Log($"[4] CameraPoint position: {location.CameraPoint.position}");
            cameraController.MoveToPoint(location.CameraPoint);
        }

        panelController.Show(location);
    }
}
