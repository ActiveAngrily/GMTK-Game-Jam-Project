using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDistanceChecker : MonoBehaviour, IChecker
{
    [SerializeField]protected float distance;
    [SerializeField] protected float checkLength;

    [SerializeField] protected Transform checkPos;

    [SerializeField] protected Vector2 direction;


    public virtual bool IsChecked()
    {
        return Physics2D.Raycast(checkPos.position, direction, checkLength);
    }
}
