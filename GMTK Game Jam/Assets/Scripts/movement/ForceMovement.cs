using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMovement : MonoBehaviour, IMove
{
    public float speed { get ; set; }
    public float defSpeed;
    public float accelariton;

    [SerializeField]Rigidbody2D rb;



    public ForceMode2D mode;



    void Awake()
    {
        speed = defSpeed;
    }

    public void Move(Vector2 input)
    {
        PhysicsHelper.ApplyForceToReachVelocity(rb, new Vector2(speed*input.x, 0), accelariton,mode);
    }

    public void ResetSpeed()
    {
        speed = defSpeed;
    }
}
