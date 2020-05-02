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
                spawnEnemies.DecreseEnemyAlive();
                Destroy(gameObject);
                SpawnExplosion(transform.position, 1);
                SpawnExplosion(new Vector3(transform.position.x + 1,transform.position.y,transform.position.z + 1), 1);
                SpawnExplosion(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), 1);
                SpawnExplosion(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), 1);
                SpawnExplosion(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1), 1);

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

    private void Oscillation()
    {
        if (!Timer.isTimeStart()) return; 
        y += 0.05f;
        x = Mathf.Sin(y);
        x *= 2;
        x += originalX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
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
}
