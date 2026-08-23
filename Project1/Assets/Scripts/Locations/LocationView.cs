using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocationView : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField]
    private int locationId;

    [SerializeField]
    private string locationName;

    [Header("Colors")]
    [SerializeField]
    private Color hoverColor = Color.white;

    [SerializeField]
    private Color selectedColor = Color.yellow;

    private Renderer[] renderers;
    private Color[] defaultColors;

    private bool isSelected;

    public int LocationId => locationId;
    public string LocationName => locationName;

    public event Action<LocationView> Clicked;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();

        defaultColors = new Color[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            defaultColors[i] = renderers[i].material.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelected)
            return;

        SetColor(hoverColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected)
            return;

        ResetColor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;

        if (selected)
            SetColor(selectedColor);
        else
            ResetColor();
    }

    private void SetColor(Color color)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = color;
        }
    }

    private void ResetColor()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = defaultColors[i];
        }
    }
}