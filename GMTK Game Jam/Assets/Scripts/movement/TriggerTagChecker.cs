using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTagChecker : MonoBehaviour, IChecker
{
    [SerializeField] string checkTag;
    bool targetInTrigger = false;

    [SerializeField] UnityEvent onEnter, onExit;
    [SerializeField] float enterTimes, exitTimes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(checkTag)){
            if(enterTimes > 0)
            {
                onEnter?.Invoke();
                enterTimes--;
            }
            targetInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(checkTag))
        {
            if (exitTimes > 0)
            {
                onExit?.Invoke();
                exitTimes--;
            }
            targetInTrigger = false;
        }
    }


    public bool IsChecked()
    {
        return targetInTrigger;
    }

}
