using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UniEventContainer : MonoBehaviour
{
    [SerializeField] UnityEvent uniEvent;

    [SerializeField] int remainingEvents;

    public void TriggerEvent()
    {
        UnityEventHelper.FireUnityEvent(uniEvent, ref remainingEvents);
    }
}
