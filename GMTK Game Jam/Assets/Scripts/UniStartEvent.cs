using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UniStartEvent : MonoBehaviour
{
    [SerializeField]
    UnityEvent onStart;

    private void Start()
    {
        onStart.Invoke();
    }
}
