using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnInterval = 10f; // Time in seconds between spawns
    public int maxAnimals = 10; // Maximum number of animals that can be spawned
    public int animalsPerGroup = 3; // Number of animals per group

    private int currentAnimalCount = 0;

    private void Start()
    {
        InvokeRepeating("TrySpawnAnimals", 0f, spawnInterval);
    }

    private void TrySpawnAnimals()
    {
        if (currentAnimalCount >= maxAnimals)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        SpawnAnimalGroup(spawnPoints[spawnPointIndex]);
    }

    private void SpawnAnimalGroup(Transform spawnPoint)
    {
        for (int i = 0; i < animalsPerGroup; i++)
        {
            if (currentAnimalCount >= maxAnimals)
            {
                break;
            }

            SpawnAnimal(spawnPoint);
        }
    }

    private void SpawnAnimal(Transform spawnPoint)
    {
        int animalIndex = Random.Range(0, AnimalPool.Instance.animalPrefabs.Length);
        string animalTag = AnimalPool.Instance.animalPrefabs[animalIndex].name;
        Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * 1f; // Adjust position slightly to avoid overlap
        spawnPosition.z = 0; // Ensure 2D position

        GameObject animal = AnimalPool.Instance.SpawnFromPool(animalTag, spawnPosition, Quaternion.identity, spawnPoint);

        if (animal != null)
        {
            currentAnimalCount++;
            AnimalMovement animalMovement = animal.GetComponent<AnimalMovement>();
            animalMovement.SetBasePoint(spawnPoint);
            // animalMovement.OnDespawn += HandleAnimalDespawn;
        }
    }

    // private void HandleAnimalDespawn()
    // {
    //     currentAnimalCount--;
    // }
}
