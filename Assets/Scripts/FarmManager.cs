using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public static FarmManager Instance { get; private set; }
    public GameObject holder;

    private List<GameObject> animalsActive = new List<GameObject>();

    private List<GameObject> animalsInFarm = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

    }

    public void AddAnimalToFarm(GameObject animal)
    {
        animal.transform.SetParent(holder.transform);
        animalsInFarm.Add(animal);
        // StartCoroutine(AnimalProduction(animal));
    }

    public void AddAnimalToActive(GameObject animal)
    {
        animalsActive.Add(animal);
    }

    private IEnumerator AnimalProduction(GameObject animal)
    {
        while (true)
        {
            yield return new WaitForSeconds(GetProductionTime(animal));
            ProduceProduct(animal);
        }
    }

    private float GetProductionTime(GameObject animal)
    {
        if (animal.CompareTag("Cow"))
            return 30f; // Produces milk every 30 seconds
        if (animal.CompareTag("Chicken"))
            return 20f; // Produces eggs every 20 seconds
        return 60f;
    }

    private void ProduceProduct(GameObject animal)
    {
        if (animal.CompareTag("Cow"))
        {
            // ProductPool.Instance.SpawnFromPool("Milk", animal.transform.position, Quaternion.identity);
        }
        else if (animal.CompareTag("Chicken"))
        {
            // ProductPool.Instance.SpawnFromPool("Egg", animal.transform.position, Quaternion.identity);
        }
    }
}
