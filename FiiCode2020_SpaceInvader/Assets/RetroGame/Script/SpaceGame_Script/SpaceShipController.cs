using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    public float moveSpeed = 1f;
    public float rotateSpeed = 10f;
    public bool run = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            run = !run;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (run)
        {
            if (moveSpeed < 10)
                moveSpeed += 0.025f;
        }
        else if (moveSpeed > 1)
            moveSpeed -= 0.025f;
        RotationProcess(); 
    }

    private void RotationProcess()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
    }
}
