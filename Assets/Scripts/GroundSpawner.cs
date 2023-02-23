using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
        
    }

    public void SpawnTile()
    {
        GameObject tempTile = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tempTile.transform.GetChild(1).transform.position;
    }
}
