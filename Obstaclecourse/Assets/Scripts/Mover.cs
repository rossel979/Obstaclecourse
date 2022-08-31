using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float fltmovespeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void PrintInstruction() 
    {
        Debug.Log("Welcome to the game");
        Debug.Log("move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls");
    }
    void MovePlayer()
    {
        float fltxValue = Input.GetAxis("Horizontal") * Time.deltaTime * fltmovespeed;
        float fltzValue = Input.GetAxis("Vertical") * Time.deltaTime * fltmovespeed;

        transform.Translate(fltxValue, 0, fltzValue);
    }
}
