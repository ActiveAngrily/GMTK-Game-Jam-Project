using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceCharged : MonoBehaviour
{
    
    [SerializeField] bool fireOnStart;


    public Vector2 forceStrentgh;
    public ForceMode2D forceMode;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    public void Start()
    {
        if (fireOnStart)
            Trigger();
    }

    public void Trigger()
    {
        rb.AddRelativeForce(transform.up * forceStrentgh,forceMode);
    }
}
