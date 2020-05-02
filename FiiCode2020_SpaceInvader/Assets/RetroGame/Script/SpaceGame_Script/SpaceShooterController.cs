using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpaceShooterController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public float leftrightSpeed = 5f;
    [SerializeField] bool canShoot = false;
    [SerializeField] AudioSource laserAudio;
    float xPosition;
    public int levelOfShooting = 1;
    public SpawnEnemies spawnEnemies;
    public GameObject bullet;
    public int health;
    public Image healthBar;
    public GameObject loseWindow;
    public GameObject pauseWindow;
    public int movementMode = 1;
    [SerializeField] GameObject explosionObj;
    Save_Level save_Level;
    bool pause;
    private void Start()
    {
        pause = false;
        save_Level = FindObjectOfType<Save_Level>();
        movementMode = save_Level.inputIndex;
        CursorMode(false);
        health = 100;
        spawnEnemies = FindObjectOfType<SpawnEnemies>();
        levelOfShooting = 1;
        leftrightSpeed = 7.5f;
        StartCoroutine(ShooterTime(0.25f));
        healthBar.fillAmount = 1;
    }

    public void CursorMode(bool mode)
    {
        if (!mode)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        if (movementMode == 1)
            if (Input.GetKey(KeyCode.Space))
            canShoot = true;
            else
                canShoot = false;
        if(movementMode == 2)
            if (Input.GetKey(KeyCode.Mouse0))
                canShoot = true;
            else
                canShoot = false;

        xPosition = Mathf.Clamp(transform.position.x, 0f, 30f);

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            if (pause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            pauseWindow.SetActive(pause);
            CursorMode(pause);
        }
    }
    void FixedUpdate()
    {
        RotationProcess();
        if (!canShoot)
        {
            if (laserAudio.isPlaying)
                laserAudio.Stop();
        }
        else
        {
            if(!laserAudio.isPlaying)
               laserAudio.Play();
        }
    }

    private void Shoot()
    {
        switch(levelOfShooting)
        {
            case 1:
                Shoots(bullet, transform.position, 2.5f,0);
                break;
            case 2:
                for (float i = -15f; i <= 15f; i+=15f)
                    Shoots(bullet, transform.position, 2.5f, i);
                break;
            case 3:
                for (float i = -30f; i <= 30f; i += 15f)
                    Shoots(bullet, transform.position, 2.5f, i);
                break;
            case 4:
                for (float i = -45f; i <= 45f; i += 15f)
                    Shoots(bullet, transform.position, 2.5f, i);
                break;
        }
    }
    private void RotationProcess()
    {
        if (movementMode == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * leftrightSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * leftrightSpeed * Time.deltaTime);
            }
        }
        else if (movementMode == 2)
        {
            transform.Translate(2.5f * Input.GetAxis("Mouse X") * Vector3.right * leftrightSpeed * Time.deltaTime);
        }
    }
    public void Shoots(GameObject bullet, Vector3 coords, float destroyTime, float angle)
    {
        coords = new Vector3(coords.x, coords.y, coords.z - 0.1f);
        BulletClass bullets = Instantiate(bullet, coords, Quaternion.Euler(0,angle,0)).GetComponent<BulletClass>();
        bullets.Initialize(10f);
        bullets.gameObject.tag = "Bullet";
        bullets.GetComponent<MeshRenderer>().material.color = Color.red;
        bullets.explosion = explosionObj;
        Destroy(bullets.gameObject, destroyTime);
    }
    public void IncreaseLevelOfShotting()
    {
        if(levelOfShooting < 4)
            levelOfShooting++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShotBonus"))
        {
            IncreaseLevelOfShotting();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyBullet"))
        {
            health -= 10;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BossBullet"))
        {
            health -= 20;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("HealthBonus"))
        {
            if(health < 100)
            health += 10;
            Destroy(other.gameObject);
        }
        if(health <= 0)
        {
            GameOver();
        }
        healthBar.fillAmount = (float)health / 100;
    }

    private void GameOver()
    {
        Timer.StopTime();
        CursorMode(true);
        loseWindow.SetActive(true); 
    }
    public IEnumerator ShooterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(canShoot)
            Shoot();
        StartCoroutine(ShooterTime(0.25f));
    }
}
