using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z <= -42f)
            transform.position = new Vector3(16, -0.5f, 158);
    }
}
