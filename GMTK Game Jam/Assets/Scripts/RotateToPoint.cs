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

   
        targetPos = target.position;

    }

    private void Update()
    {
        if (pointToCursor)
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (targetPos - (Vector2)transform.position).normalized;

        transform.up = dir;



    }
}
