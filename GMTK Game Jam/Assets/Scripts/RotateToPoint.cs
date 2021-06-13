using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPoint : MonoBehaviour
{
    public Transform target;

    Vector2 targetPos;

    Camera cam;


    [SerializeField] bool pointToCursor;

    private void Awake()
    {
        cam = Camera.main;

   
    

    }

    private void Update()
    {
        if (target == null)
        {
            //targetPos = target.position;
            if (pointToCursor)
                targetPos = cam.ScreenToWorldPoint(Input.mousePosition);


        } else
        {
            targetPos = target.position;
        }

        Vector2 dir = (targetPos - (Vector2)transform.position).normalized;

        transform.up = dir;
    }
}
