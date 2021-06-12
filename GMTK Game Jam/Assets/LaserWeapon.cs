using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    public Transform firingPos;

    public LineRenderer laserRenderer;

    public Transform test;

    private void Start()
    {
        laserRenderer.useWorldSpace = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRayCast();
        }

        Vector2 cursorPos = GameManager.instance.cursorWorldposition;
        laserRenderer.SetPosition(1, new Vector3(cursorPos.x, cursorPos.y, 0));
        laserRenderer.SetPosition(0, firingPos.position);
    }

    void ShootRayCast()
    {

        Vector2 cursorPos = GameManager.instance.cursorWorldposition;

        float distance = (cursorPos - (Vector2)firingPos.position).magnitude;
        Vector2 dir = (cursorPos - (Vector2)firingPos.position);

        //laserRenderer.SetPosition(1, new Vector3(cursorPos.x, cursorPos.y, 0));
     


        RaycastHit2D[] hits = Physics2D.RaycastAll(firingPos.position, dir.normalized, distance);

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


