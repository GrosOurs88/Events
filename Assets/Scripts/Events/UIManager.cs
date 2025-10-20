using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;

    private void OnEnable()
    {
        GameplayManager.scoreIncreased.AddListener( UpdateScoreText );      
    }

    private void OnDisable()
    {
        GameplayManager.scoreIncreased.RemoveListener( UpdateScoreText );
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
