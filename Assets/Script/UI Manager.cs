using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text lifeText;
    public TMP_Text scoreText;

    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    void Update()
    {
        lifeText.text = "Life : " + GameManager.Instance.life;
        scoreText.text = "Score : " + GameManager.Instance.score;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        finalScoreText.text =
            "Score : " + GameManager.Instance.score;
    }
}