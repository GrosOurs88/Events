using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;

    private void OnEnable()
    {
        GameplayManager.scoreIncreased.AddListener(UpdateScoreText);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
