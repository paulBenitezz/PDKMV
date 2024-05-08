using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxStats : MonoBehaviour
{

    public float MaxBoxHealth = 10f;
    public float CurrentBoxHealth;
    public Healthbar healthbar;
    public SFX SFX;
    public GameOver gameOver;

    void Awake()
    {
        CurrentBoxHealth = MaxBoxHealth;
    }
    void Start()
    {
        Debug.Log("Box Health = " + MaxBoxHealth);
        healthbar.setMaxHealth(MaxBoxHealth);
       


    }
    void Update()
    {
    
    }


    public void takeDamage(float damage)
    {
        CurrentBoxHealth -= damage;
        healthbar.setHealth(CurrentBoxHealth);
        Debug.Log("Current Box Health = " + CurrentBoxHealth);
        if (CurrentBoxHealth <= 0)
        {
            Debug.Log("BOOMBOX DESTROYED ... GAME OVER");
            gameOver.GameOverScreen("Boombox");
        }
        
        SFX.BoxHurtClip();
    }

    public void AddHealth(float health) 
    {

        if (CurrentBoxHealth != MaxBoxHealth)
        {
            CurrentBoxHealth += health;
            healthbar.setHealth(CurrentBoxHealth);
        }
            SFX.BoxHeal();
    }

    
}
