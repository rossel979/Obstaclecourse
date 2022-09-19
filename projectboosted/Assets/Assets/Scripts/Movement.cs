using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float fltmainThrust = 100f;
    [SerializeField] float fltrotationThrust = 1f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      rb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();    }
    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddRelativeForce(Vector3.up * fltmainThrust * Time.deltaTime);
        }
       
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(fltrotationThrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-fltrotationThrust);
        }
    }

    public void ApplyRotation(float fltrotationThisFrame)
    {
        rb.freezeRotation = true; // StringFreezingAttribute rotation so we can manually rotate
        transform.Rotate(Vector3.forward * fltrotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
