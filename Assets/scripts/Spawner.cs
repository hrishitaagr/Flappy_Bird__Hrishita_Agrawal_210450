// using UnityEngine;

// public class Spawner : MonoBehaviour
// {
//    public GameObject prefab;
//    public float spawnRate = 1f;
//    public float minHeight = -1f;
//    public float maxHeight = 1f;
//    private void OnEnable()
//    {
//       InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
//    }
//    private void OnDisable()
//    {
//     CancelInvoke(nameof(Spawn));
//    }
//    private void Spawn()
//    {
//     GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);
//     pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
//    }
// }

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float minSpawnRate = 0.5f; // Minimum spawn rate
    public float maxSpawnRate = 2.0f; // Maximum spawn rate

    private void OnEnable()
    {
        // Start spawning pipes immediately
        Spawn();
    }

    private void Spawn()
    {
        // Instantiate the pipe prefab
        GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);
        
        // Randomize the vertical position of the pipe
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        // Randomize the spawn rate for the next invocation
        float nextSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        
        // Schedule the next spawn with the randomized spawn rate
        Invoke(nameof(Spawn), nextSpawnRate);
    }
}


