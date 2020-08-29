using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMode : MonoBehaviour
{
    [SerializeField] GameObject[] currentCamera = new GameObject[4];
    int mode;
    void Start()
    {
        mode = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {    
            mode++;
            if(mode > 3)
                mode = 0;
            for (int i = 0; i < 4; i++)
                if (i == mode)
                    currentCamera[i].SetActive(true);
                else
                    currentCamera[i].SetActive(false);
        }
    }
}
