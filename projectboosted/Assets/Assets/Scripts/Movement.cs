using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float fltmainThrust = 100f;
    [SerializeField] float fltrotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
      rb =  GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();  }
    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();

        }
        else
        {
            StopThrust();
        }

    }

     

    void StartThrust()
    {
        rb.AddRelativeForce(Vector3.up * fltmainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    void StopThrust()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StopRotating()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    private void RotatRight()
    {
        ApplyRotation(-fltrotationThrust);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(fltrotationThrust);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    public void ApplyRotation(float fltrotationThisFrame)
    {
        rb.freezeRotation = true; // StringFreezingAttribute rotation so we can manually rotate
        transform.Rotate(Vector3.forward * fltrotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
