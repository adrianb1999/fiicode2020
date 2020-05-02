using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipHealth : MonoBehaviour
{
    public int health = 100;
    public SpaceShooterController spaceShip;
    void Start()
    {
        spaceShip = FindObjectOfType<SpaceShooterController>();
        health = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShotBonus"))
        {
            spaceShip.IncreaseLevelOfShotting();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
            Destroy(other.gameObject);
    }
}
