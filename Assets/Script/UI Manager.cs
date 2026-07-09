using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text lifeText;
    public TMP_Text scoreText;
    public TMP_Text ammoText;

    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public GunScript gun;

    void Update()
    {
        lifeText.text = "Life : " + GameManager.Instance.life;
        scoreText.text = "Score : " + GameManager.Instance.score;
        if(gun != null)
        {
            ammoText.text = gun.bulletsInTheGun.ToString();
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score : " + GameManager.Instance.score;
    }
}