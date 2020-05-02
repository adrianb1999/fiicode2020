using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int score = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            score++;
            other.gameObject.SetActive(false);
        }
    }
}
