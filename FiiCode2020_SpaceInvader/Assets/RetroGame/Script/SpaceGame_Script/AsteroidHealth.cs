using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int health = 100;
    public Score score;
    public GameObject explosion;
    List<ParticleCollisionEvent> collisionEvents;
    private void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        score = FindObjectOfType<Score>();
        explosion = GameObject.FindGameObjectWithTag("Explosion");
    }

   // [System.Obsolete]
    private void OnParticleCollision(GameObject other)
    {
        //ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
        //int x = particleSystem.GetCollisionEvents(other,collisionEvents);
        //print(collisionEvents[x].intersection);
        
        health -= 10;
        if (health <= 0)
        {
           // Score.UpdateScore(1);
            Destroy(this.gameObject);
        }
    }
}
