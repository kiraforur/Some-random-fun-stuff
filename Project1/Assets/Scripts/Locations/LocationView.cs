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

    private Renderer objectRenderer;
    private Color defaultColor;

    private bool isSelected;

    public int LocationId => locationId;
    public string LocationName => locationName;

    public event Action<LocationView> Clicked;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            defaultColor = objectRenderer.material.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelected)
        {
            return;
        }

        SetColor(hoverColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected)
        {
            return;
        }

        SetColor(defaultColor);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;

        SetColor(
            selected
                ? selectedColor
                : defaultColor
        );
    }

    private void SetColor(Color color)
    {
        if (objectRenderer == null)
        {
            return;
        }

        objectRenderer.material.color = color;
    }
}