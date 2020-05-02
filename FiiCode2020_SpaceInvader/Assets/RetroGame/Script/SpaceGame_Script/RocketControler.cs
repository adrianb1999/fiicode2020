using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControler : MonoBehaviour
{
    [SerializeField]
    Rigidbody rigidBody;
    AudioSource audioSource;
    public float moveSpeed = 100f;
    public float rotationSpeed = 5f;
    public float Fuel = 10f;
    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Fuel > 0)
        {
            MoveUp();
            Rotate();
        }
        else
            StopAll();
    }

    private void MoveUp()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Fuel -= Time.deltaTime;
            rigidBody.AddRelativeForce(Vector3.up * moveSpeed);
            PlayAll();
        }
        else
        {
            StopAll();
        }
    }

    private void PlayAll()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            Particle.SetActive(true);
        }
    }

    private void StopAll()
    {
        audioSource.Stop();
        Particle.SetActive(false);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
