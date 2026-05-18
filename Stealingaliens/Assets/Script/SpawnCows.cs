using UnityEngine;

public class SpawnCows : MonoBehaviour
{
    
    public GameObject cowPrefab; // Prefab of the cow to spawn
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float spawnInterval; // Time interval between spawns
    private float timer; // Timer to track time between spawns


    void Update()
    {
        if (Time.time >= timer) // Check if it's time to spawn a new cow
        {
            Spawn(); // Call the Spawn method to create a new cow
            timer = Time.time + spawnInterval; // Reset the timer after spawning
        }
    }

    void Spawn(){
        float randomX = Random.Range(minX, maxX); // Generate a random X position within the specified range
        float randomY = Random.Range(minY, maxY); // Generate a random Y position within the specified range

        Instantiate(cowPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation); // Instantiate the cow prefab at the calculated position with the same rotation as the spawner
    }

}
