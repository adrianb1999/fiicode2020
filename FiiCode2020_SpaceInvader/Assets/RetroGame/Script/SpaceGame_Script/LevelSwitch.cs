using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitch : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Timer.StartTime();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Timer.StartTime();
    }
}
