using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AISpawner : MonoBehaviour
{
    
    public GameObject[] SpawnLocations;
    public GameObject[] EnemyType;
    [SerializeField] float SpawnRate = 3f;

    void Start() {

        InvokeRepeating("Spawn", 1.5f, SpawnRate);
    }

    void Spawn() {
        int randLoc = Random.Range(0,SpawnLocations.Length);
        int randEne = Random.Range(0,EnemyType.Length);

        Vector3 pos = SpawnLocations[randLoc].transform.position;
        //transform.position = pos;
        Debug.Log("Spawn Location " + randLoc + " position: " + pos);
        GameObject newEnemy = Instantiate(EnemyType[randEne], pos, quaternion.identity);
        

    }
}
