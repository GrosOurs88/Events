using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventExample : MonoBehaviour
{
    public static UnityEvent<EventExample> eventTriggered = new UnityEvent<EventExample>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        eventTriggered.Invoke(this);
        Destroy(gameObject);
    }
}
