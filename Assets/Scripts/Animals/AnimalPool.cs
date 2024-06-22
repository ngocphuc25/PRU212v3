using System.Collections.Generic;
using UnityEngine;

public class AnimalPool : MonoBehaviour
{
    public static AnimalPool Instance { get; private set; }

    public GameObject[] animalPrefabs; // Prefabs to instantiate from
    public int initialPoolSize = 10;
    public GameObject holder;
    public int maxAnimalsPerPoint = 5; // Maximum animals per spawn point

    private Dictionary<string, List<GameObject>> poolDictionary;
    private Dictionary<Transform, int> spawnPointAnimalCounts;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        InitializePool();
    }

    private void InitializePool()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();
        spawnPointAnimalCounts = new Dictionary<Transform, int>();

        foreach (var animalPrefab in animalPrefabs)
        {
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(animalPrefab);
                obj.transform.SetParent(holder.transform);
                obj.SetActive(false);
                objectPool.Add(obj);
            }

            poolDictionary.Add(animalPrefab.name, objectPool);
        }
    }

    public GameObject SpawnFromPool(string animalTag, Vector3 position, Quaternion rotation, Transform spawnPoint)
    {
        if (!poolDictionary.ContainsKey(animalTag))
        {
            Debug.LogWarning("Pool with tag " + animalTag + " doesn't exist.");
            return null;
        }

        if (!spawnPointAnimalCounts.ContainsKey(spawnPoint))
        {
            spawnPointAnimalCounts[spawnPoint] = 0;
        }

        if (spawnPointAnimalCounts[spawnPoint] >= maxAnimalsPerPoint)
        {
            Debug.LogWarning("Spawn point " + spawnPoint.name + " has reached its capacity.");
            return null;
        }

        GameObject objectToSpawn = null;

        foreach (var obj in poolDictionary[animalTag])
        {
            if (!obj.activeInHierarchy)
            {
                objectToSpawn = obj;
                break;
            }
        }

        if (objectToSpawn == null)
        {
            GameObject prefab = GetPrefabByName(animalTag);
            if (prefab != null)
            {
                objectToSpawn = Instantiate(prefab);
                objectToSpawn.transform.SetParent(holder.transform);
                poolDictionary[animalTag].Add(objectToSpawn);
            }
            else
            {
                Debug.LogWarning("Prefab with name " + animalTag + " not found.");
                return null;
            }
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        spawnPointAnimalCounts[spawnPoint]++;

        return objectToSpawn;
    }

    public void ReturnToPool(GameObject animal, Transform spawnPoint)
    {
        animal.SetActive(false);

        if (spawnPointAnimalCounts.ContainsKey(spawnPoint))
        {
            spawnPointAnimalCounts[spawnPoint]--;
        }
    }

    public void RemoveAnimalFromPool(GameObject animal, Transform spawnPoint)
    {
        animal.SetActive(false);

        if (spawnPointAnimalCounts.ContainsKey(spawnPoint))
        {
            spawnPointAnimalCounts[spawnPoint]--;
        }

        // if (poolDictionary.TryGetValue(animal.name.Replace("(Clone)", ""), out var animalList))
        // {
        //     animalList.Remove(animal);
        //     Debug.Log(animalList.Count);
        // }
    }

    private GameObject GetPrefabByName(string name)
    {
        foreach (var prefab in animalPrefabs)
        {
            if (prefab.name == name)
            {
                return prefab;
            }
        }
        return null;
    }
}
