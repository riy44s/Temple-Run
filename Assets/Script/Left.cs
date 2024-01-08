using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;
    public float  timeOffset =0.4f;
    public float distanceBetweenTiles = 5.0f;
    public float randomValue = 0.8f;
    public Vector3 previousTilePosition;
    public float startTime;
    public Vector3 direction, otherDirection = new Vector3(1,0,0);

    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }
    void Update()
    {
        if(Time.time - startTime > timeOffset)
        {
            if(Random.value < randomValue)
            {
                direction = otherDirection;
            }
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos; 
        }
    }
}
