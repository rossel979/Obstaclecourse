using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fltxValue = Input.GetAxis("Horizontal");
        float fltzValue = Input.GetAxis("Vertical");
        transform.Translate(fltxValue,0, fltzValue);
    }
}
