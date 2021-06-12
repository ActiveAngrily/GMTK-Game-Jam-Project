using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jumping : MonoBehaviour
{
    [SerializeField] UnityEvent onJump;
    [SerializeField] UnityEvent onLand;

    public float jumpForceDef;

    [HideInInspector] public float jumpForce;

    public int jumpNumBase;
    [HideInInspector]public int JumpNum {get; private set;}

    [SerializeField] Rigidbody2D rb;

    IChecker checker;
    IFreezer freezer;

    bool grounded = false;

    private void Awake()
    {
        ResetForce();
        checker = GetComponent<IChecker>();
        freezer = GetComponent<IFreezer>();
        JumpNum = jumpNumBase;
    }

    private void Update()
    {
        if (grounded)
        {
            JumpNum = jumpNumBase;
        }

        grounded = checker.IsChecked();

        //Debug.Log(JumpNum);

        JumpInput();
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && freezer.canMove)
        {
            Jump();

        }
    }


    public void Jump()
    {

        if (JumpNum > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            JumpNum--;
            onJump.Invoke();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onLand.Invoke();
    }

    public void PlayParticle(ParticleSystem obj)
    {
        obj.transform.position = transform.position;
        obj.Play();
    }


    public void ResetForce()
    {
        jumpForce = jumpForceDef;
    }

    public void SetForce(float force)
    {
        jumpForce = force;
    }
}
