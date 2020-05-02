using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject[] asteriods = new GameObject[3];
    void Start()
    {
        SpawnAsteroid();
    }
    void SpawnAsteroid()
    {
        for(int i = 20; i <= 2000; i += 25)
            for (int j = 0; j <= 30; j += 15)
            {
                int k = Random.Range(0, 3);
                Instantiate(asteriods[k], new Vector3(Random.Range(j - 2,j + 3), 0, Random.Range(i - 10, i + 10)), Quaternion.identity,transform);
            }
    }
}
