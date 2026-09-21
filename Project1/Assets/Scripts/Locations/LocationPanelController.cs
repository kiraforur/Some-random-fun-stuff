using TMPro;
using UnityEngine;

public class LocationPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject panelRoot;

    [SerializeField]
    private TMP_Text locationNameText;

    public void Show(LocationView location)
    {
        if (location.UIAnchor == null)
            return;

        panelRoot.transform.position =
            location.UIAnchor.position;

        panelRoot.transform.rotation =
            location.UIAnchor.rotation;

        locationNameText.text =
            location.LocationName;

        panelRoot.SetActive(true);
    }

    public void Hide()
    {
        panelRoot.SetActive(false);
    }
}
