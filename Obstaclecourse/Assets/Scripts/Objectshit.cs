using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectshit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Bumped into wall");
    }
}
