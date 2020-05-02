using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    Save_Level save_Level;
    private void Start()
    {
        save_Level = FindObjectOfType<Save_Level>();
    }
    public void Next(int i)
    {
        save_Level.IncreaseLevel();
        SceneManager.LoadScene(i);
    }
}
