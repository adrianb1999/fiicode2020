using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Creator : MonoBehaviour
{
    int level, wave;
    
    public int[] waveLimit = { 3, 3, 4, 4, 5, 6, 7, 8, 9, 10 };
    SpawnEnemies spawnEnemies;
    void Start()
    {
        spawnEnemies = FindObjectOfType<SpawnEnemies>();
    }
    
    public void Create_Level(int level, int wave)
    {
        print("Level :" + level);
        switch(level)
        {
            case 1:
                Level_1(wave);
                break;
            case 2:
                Level_2(wave);
                break;
            case 3:
                Level_3(wave);
                break;
            case 4:
                Level_4(wave);
                break;
            case 5:
                Level_5(wave);
                break;
            case 6:
                Level_6(wave);
                break;
            case 7:
                Level_7(wave);
                break;
            case 8:
                Level_8(wave);
                break;
            case 9:
                Level_9(wave);
                break;
            case 10:
                Level_10(wave);
                break;
        }
    }

    private void Level_1(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(3, 3,"LaserEnemy", 10, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(3, 3, "RocketEnemy", 10, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(5, 3, "FireEnemy", 10, 1, 2);
                break;

        }
    }

    private  void Level_2(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(5, 2, "RocketEnemy", 10, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(6, 2, "FireEnemy", 10, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(8, 3, "LaserEnemy", 20, 1, 2);
                break;
        }
    }

    private  void Level_3(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(5, 3, "RocketEnemy", 20, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(6, 3, "LaserEnemy", 20, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(7, 3, "FireEnemy", 30, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnBoss(1);
                break;
        }
    }

    private void Level_4(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(6, 3, "FireEnemy", 30, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(7, 3, "LaserEnemy", 30, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(8, 3, "FireEnemy", 30, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(9, 3, "LaserEnemy", 30, 1, 2);
                break;
        }
    }

    private void Level_5(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(5, 3, "LaserEnemy", 40, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(6, 3, "RocketEnemy", 40, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(7, 3, "FireEnemy", 40, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(8, 3, "LaserEnemy", 40, 1, 2);
                break;
            case 5:
                spawnEnemies.SpawnEnemy(9, 3, "FireEnemy", 50, 1, 2);
                break;
        }
    }

    private void Level_6(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(3, 4, "RocketEnemy", 50, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(4, 4, "FireEnemy", 50, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(5, 4, "LaserEnemy", 50, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(6, 4, "LaserEnemy", 50, 1, 2);
                break;
            case 5:
                spawnEnemies.SpawnEnemy(7, 4, "FireEnemy", 60, 1, 2);
                break;
            case 6:
                spawnEnemies.SpawnEnemy(8, 4, "RocketEnemy", 60, 1, 2);
                break;
        }
    }

    private void Level_7(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(3, 4, "FireEnemy", 60, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(4, 4, "RocketEnemy", 60, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(5, 4, "LaserEnemy", 60, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(5, 4, "RocketEnemy", 60, 1, 2);
                break;
            case 5:
                spawnEnemies.SpawnEnemy(7, 4, "FireEnemy", 70, 1, 2);
                break;
            case 6:
                spawnEnemies.SpawnEnemy(8, 4, "LaserEnemy", 70, 1, 2);
                break;
            case 7:
                spawnEnemies.SpawnBoss(2);
                break;
        }
    }

    private void Level_8(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(3, 4, "LaserEnemy", 70, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(4, 4, "RocketEnemy", 80, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(5, 4, "LaserEnemy", 80, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(6, 4, "FireEnemy", 80, 1, 2);
                break;
            case 5:
                spawnEnemies.SpawnEnemy(7, 4, "RocketEnemy", 80, 1, 2);
                break;
            case 6:
                spawnEnemies.SpawnEnemy(8, 4, "LaserEnemy", 80, 1, 2);
                break;
            case 7:
                spawnEnemies.SpawnEnemy(9, 4, "RocketEnemy", 80, 1, 2);
                break;
            case 8:
                spawnEnemies.SpawnEnemy(10, 4, "FireEnemy", 90, 1, 2);
                break;
        }
    }

    private void Level_9(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(3, 4, "LaserEnemy", 90, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(4, 4, "RocketEnemy", 90, 1, 2);
                break;
            case 3:
                spawnEnemies.SpawnEnemy(4, 4, "FireEnemy", 90, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(5, 4, "RocketEnemy", 90, 1, 2);
                break;
            case 5:
                spawnEnemies.SpawnEnemy(6, 4, "LaserEnemy", 90, 1, 2);
                break;
            case 6:
                spawnEnemies.SpawnEnemy(7, 4, "FireEnemy", 90, 1, 2);
                break;
            case 7:
                spawnEnemies.SpawnEnemy(8, 4, "LaserEnemy", 90, 1, 2);
                break;
            case 8:
                spawnEnemies.SpawnEnemy(9, 4, "RocketEnemy", 90, 1, 2);
                break;
            case 9:
                spawnEnemies.SpawnEnemy(10, 4, "FireEnemy", 90, 1, 2);
                break;
        }
    }

    private void Level_10(int wave)
    {
        switch (wave)
        {
            case 1:
                spawnEnemies.SpawnEnemy(6, 4, "RocketEnemy", 90, 1, 2);
                break;
            case 2:
                spawnEnemies.SpawnEnemy(6, 4, "FireEnemy", 90, 1, 2); ;
                break;
            case 3:
                spawnEnemies.SpawnEnemy(7, 4, "LaserEnemy", 90, 1, 2);
                break;
            case 4:
                spawnEnemies.SpawnEnemy(8, 4, "FireEnemy", 90, 1, 2);
                break;
            case 5:
                spawnEnemies.SpawnEnemy(8, 4, "LaserEnemy", 90, 1, 2);
                break;
            case 6:
                spawnEnemies.SpawnEnemy(8, 4, "FireEnemy", 100, 1, 2);
                break;
            case 7:
                spawnEnemies.SpawnEnemy(9, 4, "RocketEnemy", 100, 1, 2);
                break;
            case 8:
                spawnEnemies.SpawnEnemy(9, 4, "LaserEnemy", 100, 1, 2);
                break;
            case 9:
                spawnEnemies.SpawnEnemy(10, 4, "RocketEnemy", 100, 1, 2);
                break;
            case 10:
                spawnEnemies.SpawnBoss(3);
                break;
        }
    }
}
