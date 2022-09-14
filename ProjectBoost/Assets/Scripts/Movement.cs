using System.Collections;
using System.Collections.Generic;
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
            ApplyRotation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * fltrotationThrust * Time.deltaTime);
        }
    }

    public void ApplyRotation()
    {
        transform.Rotate(Vector3.forward * fltrotationThrust * Time.deltaTime);
    }
}
