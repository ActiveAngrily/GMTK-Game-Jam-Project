using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    IInput input;

    IFreezer freezer;

    Jumping jumping;

    private void Awake()
    {
        input = GetComponent<IInput>();
        freezer = GetComponent<IFreezer>();
        jumping = GetComponent<Jumping>();
    }

    private void Update()
    {
        if (freezer.canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumping.JumpNum > 0)
            {
                animator.SetTrigger("jump");
            }

            if (input.Horizontal != 0)
            {
                animator.SetBool("running", true);
            }
            else
            {
                animator.SetBool("running", false);
            }
        }

    }

}
