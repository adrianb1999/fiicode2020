using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameUI scoreText;
    public int score;
    public void UpdateScore(int s)
    {
        score += s;
    }
    public void Update()
    {
        scoreText.UpdateTextScore(score);
    }
}
