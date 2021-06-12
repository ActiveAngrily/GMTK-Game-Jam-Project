using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Weapon : MonoBehaviour
{
    [SerializeField] UnityEvent onShoot;


    [SerializeField] GameObject projectile;

    public float shootDelay;

    float t;

    public Transform firingPos;


    [SerializeField]bool shootsOnClick;

    private void Awake()
    {
        t = shootDelay;
    }

    public void Shoot()
    {
        GameObject lastProjectile = Instantiate(projectile);
        lastProjectile.transform.position = firingPos.transform.position; 
        lastProjectile.transform.up = firingPos.transform.up; 
    }

    private void Update()
    {
        if (t < 0)
        {
            if (shootsOnClick && Input.GetMouseButton(0))
            {
                Shoot();
                t = shootDelay;
            }
            else if(shootsOnClick == false)
            {
                Shoot();
                t = shootDelay;
            }
        }
        else
        {
            t -= Time.deltaTime;
        }

    
    }
}
