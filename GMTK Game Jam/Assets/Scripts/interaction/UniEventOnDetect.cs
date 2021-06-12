using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UniEventOnDetect :MonoBehaviour, IDetectable
{
    public int maxDetectNum = 1;

    [SerializeField] UnityEvent onDetect;

    public void OnDetect()
    {
        if(maxDetectNum > 0)
        {
            onDetect.Invoke();
            maxDetectNum--;
        }
    }


}

