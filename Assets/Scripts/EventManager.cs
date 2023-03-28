using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent PlayerShotLandedEvent;

    private void Awake() 
    {
        PlayerShotLandedEvent.AddListener(OnPlayerShotLandedEvent);
    }

    private void OnPlayerShotLandedEvent()
    {
        // filled in the editor
    }

}
