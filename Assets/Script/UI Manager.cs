using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text lifeText;
    public TMP_Text scoreText;
    public TMP_Text ammoText;

    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    public GunInventory gunInventory;

    void Update()
    {
        lifeText.text = "Life : " + GameManager.Instance.life;
        scoreText.text = "Score : " + GameManager.Instance.score;

        if (gunInventory != null && gunInventory.currentGun != null)
        {
            GunScript currentGun = gunInventory.currentGun.GetComponent<GunScript>();

            if (currentGun != null)
            {
                ammoText.text = currentGun.bulletsInTheGun.ToString();
            }
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score : " + GameManager.Instance.score;
    }
}