using System.Collections.Generic;
using UnityEngine;

public class ProductPool : MonoBehaviour
{
    public static ProductPool Instance { get; private set; }

    public GameObject holder;
    public GameObject milkPrefab;
    // public GameObject eggPrefab;
    public int initialPoolSize = 10;

    private Dictionary<string, List<GameObject>> poolDictionary;

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

    private void Start()
    {
        // Optional: Additional initialization logic if needed
    }

    private void InitializePool()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>
        {
            { "Milk", new List<GameObject>() },
            // { "Egg", new List<GameObject>() }
        };

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject milk = Instantiate(milkPrefab);
            milk.SetActive(false);
            milk.transform.SetParent(holder.transform);
            poolDictionary["Milk"].Add(milk);

            // GameObject egg = Instantiate(eggPrefab);
            // egg.SetActive(false);
            // poolDictionary["Egg"].Add(egg);
        }
    }

    public GameObject SpawnFromPool(string productTag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(productTag))
        {
            Debug.LogWarning("Pool with tag " + productTag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = null;

        foreach (var obj in poolDictionary[productTag])
        {
            if (!obj.activeInHierarchy)
            {
                objectToSpawn = obj;
                break;
            }
        }

        if (objectToSpawn == null)
        {
            // If no inactive objects are available, instantiate a new one
            GameObject prefab = GetPrefabByName(productTag);
            if (prefab != null)
            {
                objectToSpawn = Instantiate(prefab);
                objectToSpawn.transform.SetParent(holder.transform);
                poolDictionary[productTag].Add(objectToSpawn);
            }
            else
            {
                Debug.LogWarning("Prefab with name " + productTag + " not found.");
                return null;
            }
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void ReturnToPool(GameObject product)
    {
        product.SetActive(false);
    }

    private GameObject GetPrefabByName(string name)
    {
        if (name == "Milk")
        {
            return milkPrefab;
        }
        // if (name == "Egg")
        // {
        //     return eggPrefab;
        // }
        return null;
    }
}
