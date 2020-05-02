using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float x, y = 0f, originalX;
    void Start()
    {
        y = 0f;
        originalX = transform.position.x;
    }
    void Update()
    {
        y += 0.05f;
        x = Mathf.Sin(y);
        x += originalX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

}
