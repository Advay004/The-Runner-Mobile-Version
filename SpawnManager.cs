using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab1;
    
    public float minSpawnDelay =5f;
    public float maxSpawnDelay = 10f;
    private Vector3 spawnPos1 = new Vector3(10, 0, 0);
    private PlayerControll playercontrollscript;
    private float spawnDelay = 4.0f;  // Added declaration for spawnDelay
    

    // Start is called before the first frame update
    void Start()
    {
        playercontrollscript = GameObject.Find("player").GetComponent<PlayerControll>();
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is still alive and adjust the spawn delay
        if (!playercontrollscript.GameOver)
        {
            // Randomize the delay for the next obstacle spawn
            spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    IEnumerator SpawnObstacles()
    {
        // Initial delay for the first obstacle
        yield return new WaitForSeconds(spawnDelay);

        while (!playercontrollscript.GameOver)
        {
            float randomX = Random.Range(20f,30f);
            spawnPos1 = new Vector3(randomX, spawnPos1.y, spawnPos1.z);

            Instantiate(obstaclePrefab1, spawnPos1, obstaclePrefab1.transform.rotation);

            // Use the updated spawnDelay value
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
