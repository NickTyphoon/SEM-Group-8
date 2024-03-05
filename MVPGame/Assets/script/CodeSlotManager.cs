using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CodeSlotManager : MonoBehaviour{
    //List to store references to all code slots
    public List<Slot> slots = new List<Slot>(); 
    // Start is called before the first frame update
    void Start(){
        //Add all code slots to the list
        Slot[] slotObjects = GameObject.FindObjectsOfType<Slot>();
        foreach(Slot slot in slotObjects){
            slots.Add(slot);
            Debug.Log("Slot added to CSM: " + slot.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
