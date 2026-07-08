using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text lifeText;
    public TMP_Text scoreText;

    public int life = 3;
    public int score = 0;

    void Update()
    {
        lifeText.text = "Life : " + life;
        scoreText.text = "Score : " + score;
    }
}
