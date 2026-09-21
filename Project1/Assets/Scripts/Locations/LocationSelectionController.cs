using UnityEngine;

public class LocationSelectionController : MonoBehaviour
{
    [SerializeField]
    private LocationView[] locations;

    private LocationView selectedLocation;
    public LocationView SelectedLocation => selectedLocation;

    public event System.Action<LocationView> LocationSelected;

    private void Start()
    {
        foreach (LocationView location in locations)
        {
            location.Clicked += OnLocationClicked;
        }
    }

    private void OnDestroy()
    {
        foreach (LocationView location in locations)
        {
            if (location != null)
            {
                location.Clicked -= OnLocationClicked;
            }
        }
    }

    private void OnLocationClicked(LocationView location)
    {
        Debug.Log($"[1] Clicked location: {location.LocationName}");
        if (selectedLocation != null)
        {
            selectedLocation.SetSelected(false);
        }

        selectedLocation = location;

        selectedLocation.SetSelected(true);

        Debug.Log("[2] Invoking LocationSelected");

        Debug.Log(
            $"Selected: {selectedLocation.LocationName} " +
            $"({selectedLocation.LocationId})"
        );

        LocationSelected?.Invoke(selectedLocation);
    }
}
