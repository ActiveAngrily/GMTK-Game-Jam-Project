using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] GameEvent gameEvent;
    [SerializeField] UnityEvent response;

    [SerializeField] float delay;

    public void OnEventRaised()
    {
        StartCoroutine(OnEventRaisedDelayed(delay));
    }

    private void OnEnable()
    {
        Debug.Log($"{this.gameObject.name} subscribed to {gameEvent.name}");
        gameEvent.Subscribe(this);
    }

    private void OnDisable()
    {
        gameEvent.Unsubscribe(this);
    }


    IEnumerator OnEventRaisedDelayed(float t)
    {
        yield return new WaitForSeconds(t);
        response?.Invoke();
    }
}
