using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemy = new GameObject [3];
    [SerializeField] GameObject boss;
    [SerializeField] GameObject win;
    Save_Level save_Level;
    Level_Creator level_Creator;
    GameUI gameUI;
    [SerializeField] int enemiesAlive;
    float seconds;
    int wave, level;
    GameObject currentEnemy;
    private void Start()
    {
        Timer.StartTime();
        save_Level = FindObjectOfType<Save_Level>();
        level_Creator = FindObjectOfType<Level_Creator>();
        wave = 1;
        seconds = 3f;
        enemiesAlive = 0;
        gameUI = FindObjectOfType<GameUI>();
        level = save_Level.currentLevel;
        StartCoroutine(Spawner());
    }
    public void SpawnEnemy(float nrOfCollums, float nrOfRows, string enemyType, int health, int power, int shootTime)
    {
        float collum = 30f / nrOfCollums;
        float row = 18f / nrOfRows;
        float spaceShipZ = -2f;
        float distance = 50f;
        if (enemyType == "LaserEnemy")
            currentEnemy = enemy[0];
        else if (enemyType == "RocketEnemy")
            currentEnemy = enemy[1];
        else if(enemyType == "FireEnemy")
            currentEnemy = enemy[2];

        for (float j = row * 2 + spaceShipZ; j <= 18; j += row)
        {
            for (float i = collum / 2; i <= 30; i += collum)
            {
                Vector3 enemyCoordonates = new Vector3(i, 0f, j);
                LaserEnemy Enemy = Instantiate(currentEnemy, new Vector3(i - distance, 0, j), Quaternion.identity).GetComponent<LaserEnemy>();
                Enemy.Initialize(health, power, shootTime, enemyCoordonates);
                enemiesAlive++;
            }
            distance -= 10f;
        }
    }
    public void SpawnBoss(int bossIndex)
    {
        Vector3 enemyCoordonates = new Vector3(16, 0, 14);
        EnemyBoss enemyBoss = Instantiate(boss, new Vector3(16, 0, 25), Quaternion.identity).GetComponent<EnemyBoss>();
        enemyBoss.Initialize(100, 2, 0.5f, enemyCoordonates,bossIndex);
        enemiesAlive++;
    }
    public void DecreseEnemyAlive()
    {
        enemiesAlive--;
        if (enemiesAlive == 0)
        {
            wave++;
            if (wave > level_Creator.waveLimit[level - 1])
                StartCoroutine(WinEvent());
            StartCoroutine(Spawner());
            StartCoroutine(CountDown(seconds));
            print("Wave : " + wave);
      
        }
    }
    public IEnumerator Spawner()
    {
        yield return new WaitForSeconds(seconds);
        level_Creator.Create_Level(level, wave);
    }
    public IEnumerator CountDown(float secondCount)
    {
        yield return new WaitForSeconds(1f);
        if (secondCount > 0f)
        {
            StartCoroutine(CountDown(secondCount - 1f));
        }
        else
        {
            gameUI.waveText.text = "";
        }
        if (secondCount >= 1 && wave <= level_Creator.waveLimit[level - 1])
            gameUI.waveText.text = "Next wave in " + secondCount;
    }
    public IEnumerator WinEvent()
    {
        yield return new WaitForSeconds(1f);
        win.SetActive(true);
        Timer.StopTime();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        save_Level.DataLevel[level] = true;
        save_Level.SaveFile();
    }
}
