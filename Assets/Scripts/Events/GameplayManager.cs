using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
    public static UnityEvent<int> scoreIncreased = new UnityEvent<int>();

    public int score = 0;

    private void OnEnable()
    {
        Coin.coinCollected.AddListener(IncrementScore);
    }

    public void IncrementScore(Coin coin)
    {
        score++;
        scoreIncreased.Invoke(score);
    }
}
