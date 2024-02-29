using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles drag-and-drop functionality for a UI element, implementing necessary Unity event interfaces.
/// </summary>
public class Dragdrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;    

    /// <summary>  
    /// Initializes the required components for drag-and-drop functionality.
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>  
    /// Called when the drag operation begins. Adjusts visual properties and interaction settings.
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    /// <summary>  
    /// Called during the drag operation. Updates the anchored position based on the pointer movement.
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    /// <summary>  
    /// Called when the drag operation ends. Resets visual properties and interaction settings.
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>  
    /// Called when the pointer is pressed down on the UI element.
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("OnPointerDown");
    }
}
