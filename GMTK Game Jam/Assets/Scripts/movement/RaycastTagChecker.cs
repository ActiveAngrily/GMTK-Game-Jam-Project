using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTagChecker : RaycastDistanceChecker
{
    [SerializeField] string checkTag;

    public override bool IsChecked()
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos.position, direction, checkLength);
        if (hit.collider == null)
            return false;

        return hit.collider.gameObject.CompareTag(checkTag) && hit.distance == 0;
    }

}
