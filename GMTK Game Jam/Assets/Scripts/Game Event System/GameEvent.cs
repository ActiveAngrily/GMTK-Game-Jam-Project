using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EventSystem/GameEvent",fileName = "GameEvent", order = 0)]
public class GameEvent : ScriptableObject
{
    List<EventListener> listeners;

    private void Awake()
    {
        listeners = listeners ?? new List<EventListener>();
    }

    public void Subscribe(EventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void Unsubscribe(EventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

    public void RaiseEvent()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }
    }

}
