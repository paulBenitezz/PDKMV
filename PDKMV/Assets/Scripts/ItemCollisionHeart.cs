using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionHeart : MonoBehaviour
{

    PlayerStats playerStats;

    public void Start() 
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
       
        if (playerObject != null)
        {
            playerStats = playerObject.GetComponent<PlayerStats>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

    }
    public void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pickup Heart");
            Debug.Log("Player health: " + playerStats.CurrentPlayerHealth);
            if (playerStats != null)
            {
                playerStats.AddHealth(1);
            }
            else
            {
                Debug.LogWarning("PlayerStats component is not assigned!");
            }
            //playerStats.AddHealth();
            Destroy(this.gameObject);
        }

    }


}
