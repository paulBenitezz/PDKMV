using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    
    public GameObject[] SpawnLocations;
    public GameObject[] EnemyType;


    void Start() {

        InvokeRepeating("Spawn", 1.5f, 3);
    }

    void Spawn() {
        int randLoc = Random.Range(0,SpawnLocations.Length);
        int randEne = Random.Range(0,EnemyType.Length);

        Vector3 pos = SpawnLocations[randLoc].transform.position;
        transform.position = pos;
        Debug.Log("Spawn Location " + randLoc + " position: " + pos);
        GameObject newEnemy = Instantiate(EnemyType[randEne], transform.position, transform.rotation);
        

    }
}
