using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : Interactable
{
    private void Start()
    {
        // this.promptMessage = "Open the door";    
    }
    protected override void Interact()
    {
        // base.Interact();
        Debug.Log("Interacted with " + gameObject.name);
        Debug.Log(promptMessage);
    }
}
