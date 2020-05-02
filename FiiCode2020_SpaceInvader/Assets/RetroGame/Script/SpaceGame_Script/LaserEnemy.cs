using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaserEnemy : Enemy
{
    private float x, y = 0f, originalX, moveSpeed = 10f, shootPeriod;
    private bool positionReach;
    [SerializeField] private GameObject bullet;
    [SerializeField] GameObject[] bonusShoot = new GameObject[2];
    [SerializeField] GameObject[] explosionObject = new GameObject[2];
    Score score;
    SpawnEnemies spawnEnemies;

    public override void Initialize(int health, int power, float shootTime, Vector3 coordonates2Reach)
    {
        base.Initialize(health, power, shootTime, coordonates2Reach);
    }
    void Start()
    {
        score = FindObjectOfType<Score>();
        spawnEnemies = FindObjectOfType<SpawnEnemies>();
        y = 0f;
        originalX = coordonates2Reach.x;
        shootPeriod = UnityEngine.Random.Range(shootTime, shootTime + 3);
        StartCoroutine(ShootDelay(shootPeriod));
        positionReach = false;
    }
    void Update()
    {
        if (transform.position != coordonates2Reach)
        {
            transform.position = Vector3.MoveTowards(transform.position, coordonates2Reach, moveSpeed * Time.deltaTime);
        }
        else
            positionReach = true;
        if (positionReach)
            Oscillation();
    }
    public override void Shoot(GameObject bullet, Vector3 coords, float destroyTime)
    {
        base.Shoot(bullet, coords, destroyTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (positionReach) 
                health -= 10;
            if (health == 0)
            {
                SpawnBonus();
                score.UpdateScore(1);
                spawnEnemies.DecreseEnemyAlive();
                Destroy(this.gameObject);
                SpawnExplosion(transform.position, 1);
            }
            SpawnExplosion(other.transform.position,0);
            Destroy(other.gameObject);  
        }
    }

    private void SpawnExplosion(Vector3 position, int i)
    {
        GameObject explossion = Instantiate(explosionObject[i], position, Quaternion.identity);
        Destroy(explossion, 0.1f);
    }
    private void SpawnBonus()
    {
        int randomNr = UnityEngine.Random.Range(1, 6);
        if (randomNr == 1)
        {
            int randomBonus = UnityEngine.Random.Range(0, 2);
            GameObject bonus = Instantiate(bonusShoot[randomBonus], transform.position, Quaternion.identity);
            Destroy(bonus, 5f);
        }
    }
    
    private void Oscillation()
    {
        if (!Timer.isTimeStart()) return;
        y += 0.05f;
        x = Mathf.Sin(y);
        x /= 2;
        x += originalX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    
    IEnumerator ShootDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Shoot(bullet, this.transform.position,5f);
        shootPeriod = UnityEngine.Random.Range(shootTime, shootTime + 3);
        StartCoroutine(ShootDelay(shootPeriod));
    }
   
}
