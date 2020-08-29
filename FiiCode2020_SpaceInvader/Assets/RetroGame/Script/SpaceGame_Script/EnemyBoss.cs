using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private float x, y = 0f, originalX, moveSpeed = 10f, shootPeriod;
    private bool positionReach;
    [SerializeField] private GameObject[] bullet = new GameObject[3];
    [SerializeField] GameObject[] explosionObject = new GameObject[2];
    Score score;
    SpawnEnemies spawnEnemies;
    [SerializeField] protected int type;
    [SerializeField] protected int health;
    [SerializeField] protected int power;
    [SerializeField] protected float shootTime;
    [SerializeField] protected Vector3 coordonates2Reach;
    //new 
    [SerializeField] Vector3 newCoords;
    public void Initialize(int health, int power, float shootTime, Vector3 coordonates2Reach, int type)
    {
        this.type = type;
        this.health = health;
        this.power = power;
        this.shootTime = shootTime;
        this.coordonates2Reach = coordonates2Reach;
    }
    void Start()
    {
        score = FindObjectOfType<Score>();
        spawnEnemies = FindObjectOfType<SpawnEnemies>();
        y = 0f;
        originalX = coordonates2Reach.x;
        shootPeriod = Random.Range(shootTime, shootTime + 2f);
        StartCoroutine(ShootDelay(shootPeriod));
        positionReach = false;
        newCoords = coordonates2Reach;
    }
    void FixedUpdate()
    {
        Oscillation();
    }
    public void Shoot(GameObject bullet, Vector3 coords, float destroyTime, float angle)
    {
     
        coords = new Vector3(coords.x, coords.y, coords.z - 0.1f);
        BulletClass bullets = Instantiate(bullet, coords, Quaternion.Euler(0, angle, 0)).GetComponent<BulletClass>();
        bullets.Initialize(-10f);
        bullets.gameObject.tag = "BossBullet";
        Destroy(bullets.gameObject, destroyTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (positionReach)
                health -= 10;
            if (health == 0)
            {
                score.UpdateScore(100);
                StartCoroutine(Dead());
            }
            SpawnExplosion(other.transform.position, 0);
            Destroy(other.gameObject);
        }
    }

    private void SpawnExplosion(Vector3 position, int i)
    {
        GameObject explossion = Instantiate(explosionObject[i], position, Quaternion.identity);
        Destroy(explossion, 0.1f);
    }

    private void Oscillation()// new
    {
        if (!Timer.isTimeStart()) return;
        if (transform.position == newCoords)
        {
            newCoords.x = Random.Range(coordonates2Reach.x - 2f, coordonates2Reach.x + 2f);
            newCoords.z = Random.Range(coordonates2Reach.z - 2f, coordonates2Reach.z + 2f);
            moveSpeed = 2f;
            positionReach = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, newCoords, moveSpeed * Time.deltaTime);
        }
    }
    IEnumerator ShootDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        int currentBullet;
        currentBullet = Random.Range(0, 3);
        if (type == 1)
            for (float i = -15; i <= 15; i += 15)
                Shoot(bullet[currentBullet], transform.position, 5f,i);
        if(type == 2)
            for (float i = -30; i <= 30; i += 15)
                Shoot(bullet[currentBullet], transform.position, 5f, i);
        if (type == 3)
            for (float i = -45; i <= 45; i += 15)
                Shoot(bullet[currentBullet], transform.position, 5f, i);
        shootPeriod = Random.Range(shootTime, shootTime + 2f);
        StartCoroutine(ShootDelay(shootPeriod));
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnExplosion(transform.position, 1);
        yield return new WaitForSeconds(0.5f);
        SpawnExplosion(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), 1);
        yield return new WaitForSeconds(0.5f);
        SpawnExplosion(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), 1);
        yield return new WaitForSeconds(0.5f);
        SpawnExplosion(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), 1);
        yield return new WaitForSeconds(0.5f);
        SpawnExplosion(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), 1);
        spawnEnemies.DecreseEnemyAlive(this.gameObject);
        Destroy(gameObject);
    }
}
