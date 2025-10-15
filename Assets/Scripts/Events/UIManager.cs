using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameplayManager gameplayManager;

    public TextMeshProUGUI scoreText = null;

    private void OnEnable()
    {
        GameplayManager.scoreIncreased.AddListener(UpdateScoreText);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = gameplayManager.score.ToString();
    }
}
