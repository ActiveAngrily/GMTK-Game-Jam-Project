using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMoveWithVelocity : MonoBehaviour, IMove
{

    [SerializeField] Rigidbody2D rb;




    [SerializeField] float defSpeed;
    public float speed { get; set; }



    void Awake()
    {
        ResetSpeed();
    }

    public void Move(Vector2 input)
    {
        rb.velocity = new Vector2(speed * input.x, rb.velocity.y);
    }

    public void SetSpeed(float speed)
    {
        //Debug.Log("speed changed"+speed);
        this.speed = speed;
    }

    public void ResetSpeed()
    {
        speed = defSpeed;
    }

}
