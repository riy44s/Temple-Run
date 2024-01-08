using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacls : MonoBehaviour
{
    player PlayerMovement;
    void Start()
    {
        PlayerMovement = GameObject.FindObjectOfType<player>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement.die();
        }
    }
    void Update()
    {
        
    }
}
