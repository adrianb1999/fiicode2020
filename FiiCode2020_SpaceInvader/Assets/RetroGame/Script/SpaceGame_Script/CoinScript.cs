using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] GameObject ui_element_gameobject;
    [SerializeField] float currentMoveSpeed;
    bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {    
            active = true;
            Destroy(this.gameObject, 0.4f);
        }
    }

    void FixedUpdate()
    {
        if (!active)
            return;
        Vector3 screenPoint = ui_element_gameobject.transform.position + new Vector3(0, 0, 5);  //the "+ new Vector3(0,0,5)" ensures that the object is so close to the camera you dont see it

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);

        transform.position = Vector3.MoveTowards(transform.position, worldPos, currentMoveSpeed);
    }
}
