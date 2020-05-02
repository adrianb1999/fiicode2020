using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchInput : MonoBehaviour
{
    public Sprite radioON, radioOFF;
    public Save_Level save_Level;
    public int index;
    public Image keyImage, mouseImage;
    void Start()
    {
        save_Level = FindObjectOfType<Save_Level>();
        index = save_Level.inputIndex;
        SwitchMode(index);
    }
    public void SwitchMode(int i)
    {
        index = i;
        if (index == 1)
        {
            keyImage.sprite = radioON;
            mouseImage.sprite = radioOFF;
        }
        else
        {
            keyImage.sprite = radioOFF;
            mouseImage.sprite = radioON;
        }
        save_Level.UpdateInput(index);
    }
    
}
