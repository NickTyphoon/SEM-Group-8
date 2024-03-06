using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public int finalScore;



    public void OnDrop(PointerEventData eventData){
        
        if (eventData.pointerDrag != null){
            Debug.Log("OnDrop");
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            isFilled = true;

            
            string slotName = gameObject.name;
            string fragmentName = eventData.pointerDrag.name;

            Debug.Log("Fragment dropped: " + fragmentName);

            char slotChar = slotName[slotName.Length - 2];
            char fragChar = fragmentName[fragmentName.Length - 2];

            if (slotChar == fragChar){
                isFilledCorrectly = true;
                Debug.Log("Fragment in right slot");
            }else {
                isFilledCorrectly = false;
                Debug.Log("Fragment in wrong slot");
            }

            onSlotFilled?.Invoke();
        }
    }

    void Start()
    {
        Transform parentObject;

        finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        parentObject = transform.parent.transform;

        // Update score text
        GameObject.Find("ScoreText").GetComponent<Text>().text = "You have " + finalScore / 2 + " code snippets";

        int fragmentCount = finalScore / 2;

        // Deactivate all objects starting with "CodeFragment ("
        for (int i = 0; i < parentObject.childCount; i++)
        {
            Transform child = parentObject.GetChild(i);
            if (child.name.StartsWith("CodeFragment ("))
            {
                child.gameObject.SetActive(false);
            }
        }

        // Find all objects starting with "CodeFragment (" and add them to a list
        List<GameObject> codeFragments = new List<GameObject>();
        for (int i = 0; i < parentObject.childCount; i++)
        {
            Transform child = parentObject.GetChild(i);
            if (child.name.StartsWith("CodeFragment ("))
            {
                codeFragments.Add(child.gameObject);
            }
        }

        // Iterate through the list and make as many of them active as the fragment count
        for (int i = 0; i < Mathf.Min(fragmentCount, codeFragments.Count); i++)
        {
            codeFragments[i].SetActive(true);
        }
    }

    public void GameButton()
    {
        // Debug.LogError("EndScreenButton not assigned in inspector!");
        PlayerPrefs.SetInt("FinalScore", finalScore);
        // Debug.LogError("EndScreenButton not assigned in inspector!");
        SceneManager.LoadSceneAsync("GameScene");
    }

}
