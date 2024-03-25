using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float MaxPlayerHealth = 5f;
    [SerializeField] public float MaxBoxHealth = 10f;
    public float CurrentPlayerHealth;
    public float CurrentBoxHealth;
    
    void Start() {
        Debug.Log("Player Health = " + MaxPlayerHealth);
        Debug.Log("Box Health = " + MaxBoxHealth);
        
    }


    public void takeDamage(int damage)
    {
        CurrentPlayerHealth -= damage;
        Debug.Log(CurrentPlayerHealth);
    }
}
