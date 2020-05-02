using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static void StopTime()
    {
        Time.timeScale = 0f;
    }
    public static void StartTime()
    {
        Time.timeScale = 1f;
    }
    public static bool isTimeStart()
    {
        if (Time.timeScale == 1)
            return true;
        else
            return false;
    }
    public void StartT()
    {
        Time.timeScale = 1f;
    }
}
