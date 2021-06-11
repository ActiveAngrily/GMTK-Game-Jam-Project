using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crouching : MonoBehaviour
{
    [SerializeField]GameObject player;
    IMove movementScript;

    public float crouchSpeed;

    [SerializeField]IChecker ceilingChecker;

    [SerializeField]
    Collider2D colliderToDisable;


    public UnityEvent onCrouchDown;
    public UnityEvent onCrouchUp;

    private void Awake()
    {

        movementScript = player.GetComponent<IMove>();
        ceilingChecker = GetComponent<IChecker>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            colliderToDisable.enabled = false;
            movementScript.speed = crouchSpeed;
            onCrouchDown.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            colliderToDisable.enabled = true;
            movementScript.ResetSpeed();
            onCrouchUp.Invoke();
        }

    }


}
