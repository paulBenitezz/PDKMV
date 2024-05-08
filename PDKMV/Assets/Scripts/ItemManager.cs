using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager singleton { get; private set;}

    public GameObject WrenchPrefab;
    public GameObject HeartPrefab;
    public float SpawnRate = 5f;

    private GameObject CurrentSpawnedItem;
    private float timer = 0f;

    private void Awake() 
    {
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= SpawnRate)
        {
            timer = 0f;
            SpawnItem();
        }
    }

    private void SpawnItem() 
    {
        if (CurrentSpawnedItem != null)
        {
            Destroy(CurrentSpawnedItem);
        }
        Debug.Log("item should spawn");
        GameObject prefabToSpawn = Random.Range(0, 2) == 0 ? WrenchPrefab : HeartPrefab;

        Vector2 spawnPoint = new Vector2 (Random.Range(-7.5f, 7.5f), Random.Range(-1f, -4f));
        Debug.Log("x cord: " + Random.Range(-7.5f, 7.5f) + "\ny cord: " + Random.Range(-1f, -4f));
        CurrentSpawnedItem = Instantiate(prefabToSpawn, spawnPoint, Quaternion.identity);
        

    }
}



