using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeSlotManager : MonoBehaviour{
    //List to store references to all code slots
    public List<Slot> slots = new List<Slot>();
    //To check all slots filled correctly, to check if code rearranging successful
    int numFilledCorrectly;

    public Rigidbody2D rb;

    // public Text winStateText;

    // Start is called before the first frame update
    void Start(){
        //Add all code slots to the list
        Slot[] slotObjects = GameObject.FindObjectsOfType<Slot>();
        foreach(Slot slot in slotObjects){
            //Subscribe to onSlotilled event for each slot
            slot.onSlotFilled += CheckAllSlotsCorrect;


            slots.Add(slot);
            Debug.Log("Slot added to CSM: " + slot.gameObject.name);
        }
        numFilledCorrectly = 0;
    }

    // Update is called once per frame
    void Update(){
        
    }

    //Check all slots filled correctly and print success
    public void CheckAllSlotsCorrect(){
        //If isFilledCorrectly == true, then don't need to check if isFilled = true?
        //Reset numFC to 0 slots checked, so don't carry over.
        numFilledCorrectly = 0;
        foreach (Slot slot in slots)
        {
            //If one of the slots is filled incorrectly, then no point checking others
            if (slot.isFilled && !slot.isFilledCorrectly)
            {
                break;
            }
            if (slot.isFilled && slot.isFilledCorrectly)
            {
                numFilledCorrectly++;
                Debug.Log("num filled correctly: " + numFilledCorrectly);
            }
        }
        if (numFilledCorrectly == 4)
        {
            Debug.Log("Code snippets in the right order, Success!");

            rb = GetComponent<Rigidbody2D>();
            GameObject.Find("WinStateText").GetComponent<Text>().text = "Code snippets in the right order, Success!";

            // Text winStateText = GameObject.Find("WinStateText")?.GetComponent<Text>();
            // if (winStateText != null)
            // {
            //     winStateText.text = "Code snippets in the right order, Success!";
            // }

        }
    }
}
