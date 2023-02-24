using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    
    [SerializeField] Transform[] obstacleSpawnPoints;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Transform[] pickupSpawnPoints;
    [SerializeField] GameObject[] pickupPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        Transform spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)];
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnPickup()
    {
        GameObject pickupToSpawn = pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];
        Transform spawnPoint = pickupSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)];
        Instantiate(pickupToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
