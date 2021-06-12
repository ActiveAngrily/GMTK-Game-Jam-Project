using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSphereChecker : MonoBehaviour, IChecker
{
    [SerializeField] Transform[] groundCheckPositions;
    [SerializeField] float checkLength = 0f;

    [SerializeField] LayerMask ground;

    public bool IsChecked()
    {
        bool grounded = false;

        for (int i = 0; i < groundCheckPositions.Length; i++)
        {
            if (Physics2D.OverlapCircle(groundCheckPositions[i].position, checkLength, ground))
            {
                grounded = true;
                break;
            }
        }

        return grounded;

    }
}
