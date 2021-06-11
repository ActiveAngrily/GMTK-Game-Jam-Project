using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    Collider2D collision;
    bool inTrigger = false;

    [SerializeField]

    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            InteractCheck();
        }

        void InteractCheck()
        {
            if (collision.gameObject.GetComponent<IInteractable>() != null)
            {
                collision.gameObject.GetComponent<IInteractable>().OnInteract();
            }
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.collision = collision;
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.collision = collision;
        inTrigger = false;
    }
}
