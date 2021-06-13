using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventRaiser : MonoBehaviour
{
    [SerializeField] GameEvent gameEvent;


    public void Raise()
    {
        gameEvent.RaiseEvent();
    }
}
