using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    public Transform firingPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRayCast();
        }
    }

    void ShootRayCast()
    {

        Vector2 cursorPos = GameManager.instance.cursorWorldposition;

        float distance = (cursorPos - (Vector2)firingPos.position).magnitude;
        Vector2 dir = (cursorPos - (Vector2)firingPos.position).normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(firingPos.position, dir, distance);

        if (hits.Length > 0)
        {
            foreach (var hitInfo in hits)
            {
                //Todo: damage each enemy
                Debug.Log(hitInfo.collider.gameObject.name);
            }
        }
    }

}


