using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour, IChecker
{

    [SerializeField] Transform groundCheck;
    [SerializeField] float checkLength = 0f;

    [SerializeField] LayerMask ground;

    public bool IsChecked()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkLength, ground);
    }
}
