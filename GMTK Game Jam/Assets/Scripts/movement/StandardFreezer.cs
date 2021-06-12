using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFreezer : MonoBehaviour, IFreezer
{
    public bool canMove { get; set; }


    public void Freeze(bool x)
    {
        canMove = !x;
    }

    void Awake()
    {
        canMove = true;
    }



}
