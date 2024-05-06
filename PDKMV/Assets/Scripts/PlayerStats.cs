using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float MaxPlayerHealth = 5f;
    public float CurrentPlayerHealth;
    public Healthbar healthbar;
    public SFX SFX;
    public bool isMale;

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


    public void takeDamage(float damage)
    {
        CurrentPlayerHealth -= damage;
        healthbar.setHealth(CurrentPlayerHealth);
        Debug.Log("Current Player Health = " + CurrentPlayerHealth);

        if (CurrentPlayerHealth <= 0)
        {
            Debug.Log("PLAYER DIED ... GAME OVER");
            SceneManager.LoadScene("MainMenu");
        }

        if (isMale) {
            SFX.PlayerHurtMaleClip();
        }
        else {
            SFX.PlayerHurtFemaleClip();
        }
    }    
}
