using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Transform target;

    bool facingRight = true;

    public bool FacingRight => facingRight;




    private void Update()
    {

        if (rb.velocity.x > 0)
            facingRight = true;
        else if (rb.velocity.x < 0)
            facingRight = false;


        if (facingRight)
        {
            target.localRotation = Quaternion.Euler(target.localRotation.x, 180, target.localRotation.z);
        }
        else
        {
            target.localRotation = Quaternion.Euler(target.localRotation.x, 0, target.localRotation.z);
        }


    }
}
