using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UIManager uiManager;

    public int score = 0;
    public int life = 3;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        uiManager.ShowGameOver();

        Time.timeScale = 0f;
    }
}