using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    private bool hasBeenCollected = false;

  
    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenCollected)
        {
            return;
        }
        if (other.gameObject.GetComponent<Obstacls>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.name != "Player")
        {
            return;
        }
        GameManeger.inst.IncrementScore();
        hasBeenCollected = true;
        Destroy(gameObject);
       
    }
    private void Update()
    {
        transform.Rotate(0,0,turnSpeed*Time.deltaTime);
    }
}
