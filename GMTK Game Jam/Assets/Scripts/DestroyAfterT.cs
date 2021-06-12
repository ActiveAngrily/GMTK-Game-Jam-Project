using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(UniEventContainer))]
public class DestroyAfterT : MonoBehaviour
{
    [SerializeField] float delay;

    UniEventContainer eventContainer;

    private void Awake()
    {
        eventContainer = GetComponent<UniEventContainer>();
    }

    private void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(delay);
        eventContainer.TriggerEvent();
        Destroy(gameObject);
    }


}
