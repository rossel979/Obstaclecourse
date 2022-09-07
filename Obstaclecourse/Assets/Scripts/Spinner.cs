using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float fltxAngle = 0;
    [SerializeField] float fltyAngle = 0;
    [SerializeField] float fltzAngle = 0;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(fltxAngle, fltyAngle, fltzAngle);
    }
}
