using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreText, waveText,levelText;
    public RectTransform healthImage, restartButton;
    public RectTransform winPanel, win_Next, win_Exit, win_Title, win_Score;
    public RectTransform losePanel, lose_Restart, lose_Exit, lose_Title, lose_Score;
    public RectTransform pausePanel, pause_Restart, pause_Exit, pause_Title, pause_Back;
    Save_Level save_Level;
    private void Start()
    {
        Initialize();
        save_Level = FindObjectOfType<Save_Level>();
        UpdateTextLevel(save_Level.currentLevel);
    }
    private void Initialize()
    {
        healthImage.sizeDelta = new Vector2(Screen.width / 5, Screen.width / 25);
        healthImage.transform.position = new Vector2(healthImage.sizeDelta.x / 2 + healthImage.sizeDelta.y / 2, healthImage.sizeDelta.y);

        restartButton.sizeDelta = new Vector2(Screen.width / 5, Screen.width / 25);
        
        scoreText.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 5, Screen.width / 10);
        scoreText.GetComponent<RectTransform>().transform.position = new Vector2(Screen.width / 10, Screen.height - Screen.width / 20);
        scoreText.fontSize = (int)Screen.height / 30;
        scoreText.text = "";

        levelText.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 5, Screen.width / 10);
        levelText.GetComponent<RectTransform>().transform.position = new Vector2(Screen.width - Screen.width / 10, Screen.height - Screen.width / 20);
        levelText.fontSize = (int)Screen.height / 30;

        waveText.fontSize = (int)Screen.height / 20;

        winPanel.sizeDelta = new Vector2(Screen.height * 0.50f, Screen.height * 0.75f);
        winPanel.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        win_Title.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        win_Title.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.78125f);
        win_Title.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        win_Score.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        win_Score.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.59375f);
        win_Score.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        win_Next.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        win_Next.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.40625f);
        win_Next.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        win_Exit.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        win_Exit.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.21875f);
        win_Exit.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        //LOSE:
        losePanel.sizeDelta = new Vector2(Screen.height * 0.50f, Screen.height * 0.75f);
        losePanel.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        lose_Title.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        lose_Title.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.78125f);
        lose_Title.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        lose_Score.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        lose_Score.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.59375f);
        lose_Score.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        lose_Restart.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        lose_Restart.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.40625f);
        lose_Restart.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        lose_Exit.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        lose_Exit.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.21875f);
        lose_Exit.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        //PAUSE
        pausePanel.sizeDelta = new Vector2(Screen.height * 0.50f, Screen.height * 0.75f);
        pausePanel.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        pause_Title.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        pause_Title.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.78125f);
        pause_Title.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        pause_Restart.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        pause_Restart.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.59375f);
        pause_Restart.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        pause_Exit.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        pause_Exit.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.40625f);
        pause_Exit.GetComponent<Text>().fontSize = (int)Screen.height / 25;

        pause_Back.sizeDelta = new Vector2(Screen.height / 2, Screen.height * 0.1875f);
        pause_Back.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.21875f);
        pause_Back.GetComponent<Text>().fontSize = (int)Screen.height / 25;
    }
    public void UpdateTextScore(int score)
    {
        if (score != 0)
        {
            scoreText.text = "Score:" + score;
            win_Score.GetComponent<Text>().text = scoreText.text;
            lose_Score.GetComponent<Text>().text = scoreText.text;
        }
    }
    public void UpdateTextLevel(int level)
    {
        levelText.text = "Level:" + level;
    }
}
