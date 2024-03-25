using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float MaxPlayerHealth = 5f;
    public float CurrentPlayerHealth;
    public Healthbar healthbar;
    

    void Awake() {
        CurrentPlayerHealth = MaxPlayerHealth;
    }
    void Start() {
        Debug.Log("Player Health = " + MaxPlayerHealth);
        healthbar.setMaxHealth(MaxPlayerHealth);
        
        
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(1);
          
        }


    }


    public void takeDamage(int damage)
    {
        CurrentPlayerHealth -= damage;
        healthbar.setHealth(CurrentPlayerHealth);
        Debug.Log("Current Player Health = " + CurrentPlayerHealth);

        if (CurrentPlayerHealth <= 0)
        {
            Debug.Log("PLAYER DIED ... GAME OVER");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
