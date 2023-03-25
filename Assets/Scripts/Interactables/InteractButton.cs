using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : Interactable
{
    public GameObject affectedObject;
    private bool isOpen;

    protected override void Interact()
    {
        //Debug.Log("Interacted with " + gameObject.name);
        //affectedObject.SetActive(!affectedObject.activeSelf);

        isOpen = !isOpen;
        affectedObject.GetComponent<Animator>().SetBool("IsOpen", isOpen);
    }
}
