using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour, IInput
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    [SerializeField] float horizontalMultiplier = 1f;
    [SerializeField] float verticalMultiplier = 1f;

    void Update()
    {
        GetInput();
    }
    void GetInput()
    {
        Horizontal = Mathf.Round(Input.GetAxisRaw("Horizontal")) * horizontalMultiplier;
        Vertical = Mathf.Round(Input.GetAxisRaw("Vertical")) * verticalMultiplier;
    }



}
