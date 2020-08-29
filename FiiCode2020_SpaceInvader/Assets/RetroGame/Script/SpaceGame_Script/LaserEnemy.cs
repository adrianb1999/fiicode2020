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
    //new 
    [SerializeField] Vector3 newCoords;
    [SerializeField] bool trigger;
    public override void Initialize(int health, int power, float shootTime, Vector3 coordonates2Reach)
    {
        base.Initialize(health, power, shootTime, coordonates2Reach);
    }
    void Start()
    {
        trigger = false;
        score = FindObjectOfType<Score>();
        spawnEnemies = FindObjectOfType<SpawnEnemies>();
        y = 0f;
        originalX = coordonates2Reach.x;
        shootPeriod = UnityEngine.Random.Range(shootTime, shootTime + 3);
        StartCoroutine(ShootDelay(shootPeriod));
        positionReach = false;
        newCoords = coordonates2Reach;
    }
    void FixedUpdate()
    {
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
                spawnEnemies.DecreseEnemyAlive(this.gameObject);
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
    
    private void Oscillation() // new
    {
        if (!Timer.isTimeStart()) return;
        if (transform.position == newCoords)
        {
            if (!trigger)
            {
                moveSpeed = 2f;
                newCoords.x = UnityEngine.Random.Range(coordonates2Reach.x - 2f, coordonates2Reach.x + 2f);
                newCoords.z = UnityEngine.Random.Range(coordonates2Reach.z - 2f, coordonates2Reach.z + 2f);
            }
            else
            {
                newCoords.x = UnityEngine.Random.Range(8f, 24f);
                newCoords.z = UnityEngine.Random.Range(4f, 6f);
                moveSpeed = 5f;
            }
            positionReach = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, newCoords, moveSpeed * Time.deltaTime);
        }
    }
    public void TriggerAbility()// new 
    {
        trigger = true;
        StartCoroutine(TriggerTimer());
    }
    IEnumerator ShootDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Shoot(bullet, this.transform.position,5f);
        shootPeriod = UnityEngine.Random.Range(shootTime, shootTime + 3);
        StartCoroutine(ShootDelay(shootPeriod));
    }
    public IEnumerator TriggerTimer()
    {
        yield return new WaitForSeconds(5f);
        trigger = false;
        yield return new WaitForSeconds(5f);
        moveSpeed = 2f;
    }
   
}
