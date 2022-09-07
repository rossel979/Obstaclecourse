using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Objectshit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 1f, 1f);
            gameObject.tag = "Hit";
        }
    }
}
