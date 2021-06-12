using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousInput : MonoBehaviour, IInput
{
    public float Horizontal { get; set; }

    public float Vertical { get; set; }

    public Vector2 input;

    void Update()
    {
        Horizontal = input.x;
        Vertical = input.y;
    }
}
