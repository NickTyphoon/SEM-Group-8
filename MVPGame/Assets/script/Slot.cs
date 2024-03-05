using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the drop behavior for UI elements, implementing the IDropHandler interface.
/// </summary>
public class Slot : MonoBehaviour, IDropHandler{
    /// <summary>
    /// Called when a UI element is dropped onto this object. Adjusts the anchored position of the dragged element.
    /// </summary>
    /// <param name="eventData">The pointer event data associated with the drop.</param>

    public bool isFilled = false;
    public bool isFilledCorrectly = false;

    //Event to notify CSM when slot filled
    public event Action onSlotFilled;

    public void OnDrop(PointerEventData eventData){
        
        if (eventData.pointerDrag != null){
            Debug.Log("OnDrop");
            // Set the anchored position of the dragged element to match the position of this object.
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            isFilled = true;

            
            //Get slot name and fragment name
            string slotName = gameObject.name;
            string fragmentName = eventData.pointerDrag.name;

            Debug.Log("Fragment dropped: " + fragmentName);

            //Get char of number of slot and fragment
            char slotChar = slotName[slotName.Length - 2];
            char fragChar = fragmentName[fragmentName.Length - 2];

            //Check fragment in correct slot
            if (slotChar == fragChar){
                isFilledCorrectly = true;
                Debug.Log("Fragment in right slot");
            }else {
                isFilledCorrectly = false;
                Debug.Log("Fragment in wrong slot");
            }

            //Trigger the onSlotFilled event
            onSlotFilled?.Invoke();
        }
    }
}
