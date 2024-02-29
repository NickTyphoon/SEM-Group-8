using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the drop behavior for UI elements, implementing the IDropHandler interface.
/// </summary>
public class NewBehaviourScript : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// Called when a UI element is dropped onto this object. Adjusts the anchored position of the dragged element.
    /// </summary>
    /// <param name="eventData">The pointer event data associated with the drop.</param>
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // Set the anchored position of the dragged element to match the position of this object.
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
