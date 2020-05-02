using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu_UI : MonoBehaviour
{
    Save_Level save_Level;
    [SerializeField] RectTransform StartButton, OptionButton, ExitButton, BackButton, Title;
    [SerializeField] RectTransform[] LevelButton = new RectTransform[10];
    [SerializeField] RectTransform setting_panel, setting_title, setting_back, setting_mouseInput, setting_keyInput, mouseInput_Text, keyInput_text;
    void Start()
    {
        save_Level = FindObjectOfType<Save_Level>();
        Initialize_UI();
        SettingUI();
        LoadLevelInformation();
    }

    private void LoadLevelInformation()
    {
        for (int i = 0; i <= 9; i++)
            LevelButton[i].GetComponent<Button>().interactable = save_Level.DataLevel[i];
    }
    private void SettingUI()
    {
        setting_panel.sizeDelta = new Vector2(Screen.height * 0.5625f, Screen.height * 0.75f);
        setting_panel.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        setting_title.sizeDelta = new Vector2(Screen.height * 0.5625f, Screen.height * 0.1875f);
        setting_title.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.78125f);
        setting_title.GetComponent<Text>().fontSize = (int)Screen.height / 20;

        setting_mouseInput.sizeDelta = new Vector2(Screen.height * 0.05f, Screen.height * 0.05f);
        setting_mouseInput.transform.position = new Vector2(Screen.width / 2 - Screen.height * 0.5625f * 0.375f, Screen.height * 0.59375f);

        mouseInput_Text.sizeDelta = new Vector2(Screen.height * 0.5625f * 0.75f, Screen.height * 0.1875f);
        mouseInput_Text.transform.position = new Vector2(Screen.width / 2 + Screen.height * 0.5625f * 0.125f, Screen.height * 0.59375f);
        mouseInput_Text.GetComponent<Text>().fontSize = (int)Screen.height / 45;

        setting_keyInput.sizeDelta = new Vector2(Screen.height * 0.05f, Screen.height * 0.05f);
        setting_keyInput.transform.position = new Vector2(Screen.width / 2 - Screen.height * 0.5625f * 0.375f, Screen.height * 0.40625f);

        keyInput_text.sizeDelta = new Vector2(Screen.height * 0.5625f * 0.75f, Screen.height * 0.1875f);
        keyInput_text.transform.position = new Vector2(Screen.width / 2 + Screen.height * 0.5625f * 0.125f, Screen.height * 0.40625f);
        keyInput_text.GetComponent<Text>().fontSize = (int)Screen.height / 45;

        setting_back.sizeDelta = new Vector2(Screen.height * 0.5625f, Screen.height * 0.1875f);
        setting_back.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.21875f);
        setting_back.GetComponent<Text>().fontSize = (int)Screen.height / 25;
    }
    private void Initialize_UI()
    {
        Title.sizeDelta = new Vector2(Screen.height * 0.6f, Screen.height * 0.2f);
        Title.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.85f);
        //Title.GetComponent<Text>().fontSize = (int)Screen.height / 10;

        StartButton.sizeDelta = new Vector2(Screen.height / 1.5f,Screen.height / 9);
        StartButton.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.55f);
        StartButton.GetComponent<Text>().fontSize =(int) Screen.height / 17;

        OptionButton.sizeDelta = new Vector2(Screen.height / 1.5f, Screen.height / 9); //Optinuni de selectat fie mouse / WASD + SPACE
        OptionButton.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.39f);
        OptionButton.GetComponent<Text>().fontSize = (int)Screen.height / 17;

        ExitButton.sizeDelta = new Vector2(Screen.height / 1.5f, Screen.height / 9);
        ExitButton.transform.position = new Vector2(Screen.width / 2, Screen.height * 0.23f);
        ExitButton.GetComponent<Text>().fontSize = (int)Screen.height/ 17;

        LevelButton[0].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[0].transform.position = new Vector2(Screen.width * 0.1f , Screen.height * 0.65f);

        LevelButton[1].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[1].transform.position = new Vector2(Screen.width * 0.3f, Screen.height * 0.65f);

        LevelButton[2].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[2].transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.65f);

        LevelButton[3].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[3].transform.position = new Vector2(Screen.width * 0.7f, Screen.height * 0.65f);

        LevelButton[4].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[4].transform.position = new Vector2(Screen.width * 0.9f, Screen.height * 0.65f);

        LevelButton[5].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[5].transform.position = new Vector2(Screen.width * 0.1f, Screen.height * 0.35f);

        LevelButton[6].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[6].transform.position = new Vector2(Screen.width * 0.3f, Screen.height * 0.35f);

        LevelButton[7].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[7].transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.35f);

        LevelButton[8].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[8].transform.position = new Vector2(Screen.width * 0.7f, Screen.height * 0.35f);

        LevelButton[9].sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
        LevelButton[9].transform.position = new Vector2(Screen.width * 0.9f, Screen.height * 0.35f);

        BackButton.sizeDelta = new Vector2(Screen.height / 2.5f, Screen.height / 5);
        BackButton.transform.position = new Vector2(Screen.height / 5, Screen.height - Screen.height / 10);
        BackButton.GetComponent<Text>().fontSize = (int)Screen.height / 20;

        for (int i = 0; i < 9; i++)
        {
            LevelButton[i].GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 10, Screen.height / 10);
            //GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
          //  LevelButton[i].GetComponentInChildren<RectTransform>().transform.position = LevelButton[i].transform.position;
        }
        LevelButton[9].GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 5, Screen.height / 5);
    }
    
    public void InitializeLevels(int level)
    {
        save_Level.InitializeLevel(level);
    }
   
}
