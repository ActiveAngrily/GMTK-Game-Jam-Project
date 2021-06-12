using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    IInput input;
    IChecker checker;
    IMove movement;
    IFreezer freezer;

    private void Awake()
    {
        input = GetComponent<IInput>();
        checker = GetComponent<IChecker>();
        movement = GetComponent<IMove>();
        freezer = GetComponent<IFreezer>();
    }

    private void FixedUpdate()
    {
        if (freezer.canMove)
        {
            movement.Move(new Vector2(input.Horizontal, input.Vertical));
        }
        else
        {
            movement.Move(new Vector2(0, 0));
        }
    }


}
