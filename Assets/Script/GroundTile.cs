using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner spawner;
    public GameObject coinPrefab;
    public GameObject HeightObstaclsPrefab;
   public float HieghtObstacls=0.2f;

    public void Start()
    {
        spawner = GameObject.FindObjectOfType<GroundSpawner>();
       
    }
    private void OnTriggerExit(Collider other)
    {
        spawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }
    public GameObject obstaclePrefab;
   /* public GameObject leftPrefab;
    public void leftSpawn()
    {
        Vector3 left = new Vector3 (1, 0, 0);
        GameObject temp = Instantiate(leftPrefab,left, Quaternion.identity);
        left = temp.transform.GetChild(5).transform.position;
    }*/
    public void spawnOstacls()
    {
       /* GameObject obstacleToSpawn = HeightObstaclsPrefab;
        float random = Random.Range(0f, 1f);
        if (random < HieghtObstacls)
        {
            obstacleToSpawn = HeightObstaclsPrefab; 
        }*/

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    public void spawnHieghtObstracles()
    {
        GameObject obstacleToSpawn = HeightObstaclsPrefab;
        int random = Random.Range(0, 1);
        if (random < HieghtObstacls)
        {
            obstacleToSpawn = HeightObstaclsPrefab;
        }
        Transform spawnPoint1 = transform.GetChild(random).transform;
        Instantiate(obstacleToSpawn, spawnPoint1.position, Quaternion.identity, transform);
    }
    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomCoin(Collider collider)
    {
        Vector3 point = new Vector3
            (
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomCoin(collider);
        }
        point.y = 1;
        return point;
    }
}
