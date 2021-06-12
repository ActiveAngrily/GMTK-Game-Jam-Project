using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UniEventContainer))]
public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] bool onTriggerDestroy;
    UniEventContainer eventContainer;

    private void Awake()
    {
        eventContainer = GetComponent<UniEventContainer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        eventContainer.TriggerEvent();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventContainer.TriggerEvent();
        if (onTriggerDestroy)
            Destroy(this.gameObject);

    }
}
