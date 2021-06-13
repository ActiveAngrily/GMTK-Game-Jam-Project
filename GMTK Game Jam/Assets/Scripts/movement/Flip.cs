using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform hand;

    [SerializeField] Transform target;

    bool facingRight = true;

    public bool FacingRight => facingRight;




    private void Update()
    {

        if (rb.velocity.x > 0)
            facingRight = true;
        else if (rb.velocity.x < 0)
            facingRight = false;


        if (Input.GetKeyDown(KeyCode.D))
        {
            FlipPlayer(Direction.Right);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            FlipPlayer(Direction.Left);
        }

       
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1) || Mathf.Round(Input.GetAxisRaw("Horizontal")) == 0)
        {

            if (hand.localEulerAngles.z < 360 && hand.localEulerAngles.z > 180)
            {
                FlipPlayer(Direction.Right);
            }

            if ((hand.localEulerAngles.z < 360 && hand.localEulerAngles.z > 180) == false)
            {
                FlipPlayer(Direction.Left);
            }
        }


    }

    public void FlipPlayer(Direction direction)
    {
        float y = 0;
        if (direction == Direction.Right)
            y = 180;

        target.localRotation = Quaternion.Euler(target.localRotation.x, y, target.localRotation.z);
    }
}
