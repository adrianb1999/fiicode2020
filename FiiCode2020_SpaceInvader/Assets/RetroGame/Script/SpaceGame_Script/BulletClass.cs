using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    float force;
    Rigidbody rb;
    public GameObject explosion;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * force);
    }
    public void Initialize(float force)
    {
        this.force = force;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * force * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Bullet") && other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameObject explosionObject = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explosionObject, 0.1f);
        }
        if(gameObject.CompareTag("EnemyBullet") && other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameObject explosionObject = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explosionObject, 0.1f);
        }
    }
}
