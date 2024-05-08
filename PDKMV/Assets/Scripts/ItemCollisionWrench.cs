using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionWrench : MonoBehaviour
{

    BoxStats boxstats;
    
    public void Start() 
    {
        GameObject boxObject = GameObject.FindGameObjectWithTag("Boombox");
        if (boxObject != null)
        {
            boxstats = boxObject.GetComponent<BoxStats>();
        }
        else
        {
            Debug.LogError("Boombox object not found!");
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pickup Wrench");
            boxstats.AddHealth(2);
            Destroy(this.gameObject);
        }

    }


}
