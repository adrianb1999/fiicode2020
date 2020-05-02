using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected int health;
    [SerializeField] protected int power;
    [SerializeField] protected float shootTime;
    [SerializeField] protected Vector3 coordonates2Reach;

    public virtual void Initialize(int health, int power, float shootTime,Vector3 coordonates2Reach)
    {
        this.health = health;
        this.power = power;
        this.shootTime = shootTime;
        this.coordonates2Reach = coordonates2Reach;
    }
    public virtual void Shoot(GameObject bullet, Vector3 coords, float destroyTime)
    {
        coords = new Vector3(coords.x, coords.y, coords.z - 0.1f);
        BulletClass bullets = Instantiate(bullet, coords, Quaternion.identity).GetComponent<BulletClass>();
        bullets.Initialize(-10f);
        bullets.gameObject.tag = "EnemyBullet";
        Destroy(bullets.gameObject, destroyTime);
    }
    
}