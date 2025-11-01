using UnityEngine;
using UnityEngine.Events;

public class EventListenerExample : MonoBehaviour
{
    public static UnityEvent<int> scoreIncreased = new UnityEvent<int>();

    public int score = 0;

    private void OnEnable()
    {
        EventExample.eventTriggered.AddListener(IncrementScore);
    }

    private void OnDisable()
    {
        EventExample.eventTriggered.RemoveListener(IncrementScore);
    }

    public void IncrementScore(EventExample eventName)
    {
        score++;
        scoreIncreased.Invoke(score);
    }
}
