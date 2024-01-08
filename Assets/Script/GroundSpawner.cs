
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
   
    public void SpawnTile(bool sapwnTiles)
    {
       GameObject temp = Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);
       nextSpawnPoint = temp.transform.GetChild(1).transform.position;
      

       if(sapwnTiles )
       {
            /*temp.GetComponent<GroundTile>().leftSpawn();*/
            temp.GetComponent<GroundTile>().spawnOstacls();
            temp.GetComponent<GroundTile>().SpawnCoins();
            temp.GetComponent<GroundTile>().spawnHieghtObstracles();
       }
    }
    private void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}
