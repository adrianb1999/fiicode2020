using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterMovement : MonoBehaviour
{
    public float moveAxis, turnAxis;
    private float rotateSpeed = 100f;
    private float moveSpeed = 5f;
    private Rigidbody rb;

    public float jumpForce = 10f;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveAxis = Input.GetAxis("Vertical"); 
        turnAxis = Input.GetAxis("Horizontal");
        ApplyInput(moveAxis, turnAxis);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void ApplyInput(float moveAxis, float turnAxis)
    {
        Move(moveAxis);
        Turn(turnAxis);
    }

    private void Move(float moveAxis)
    {
        if (moveAxis < 0)
            return;
        transform.Translate(transform.forward * moveAxis * moveSpeed *Time.deltaTime, Space.World);
    }
    private void Turn(float turnAxis)
    {
        transform.Rotate(0f,rotateSpeed* turnAxis * Time.deltaTime, 0f);
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
