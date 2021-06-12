using UnityEngine.Events;
using UnityEngine;

public class UniEventOnInteract : MonoBehaviour, IInteractable
{
    public int maxInteractNum = 1;

    [SerializeField] UnityEvent onInteract;

    public void OnInteract()
    {
        if (maxInteractNum > 0)
        {
            onInteract.Invoke();
            maxInteractNum--;
        }
    }


}

