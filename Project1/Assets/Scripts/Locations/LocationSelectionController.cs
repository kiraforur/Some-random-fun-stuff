using UnityEngine;

public class LocationSelectionController : MonoBehaviour
{
    [SerializeField]
    private LocationView[] locations;

    private LocationView selectedLocation;

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
        if (selectedLocation != null)
        {
            selectedLocation.SetSelected(false);
        }

        selectedLocation = location;

        selectedLocation.SetSelected(true);

        Debug.Log(
            $"Selected: {selectedLocation.LocationName} " +
            $"({selectedLocation.LocationId})"
        );
    }
}
