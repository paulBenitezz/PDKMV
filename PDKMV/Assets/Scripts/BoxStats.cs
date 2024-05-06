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
    public AudioSource aud;

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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            takeDamage(1);
        }
    }


    public void takeDamage(float damage)
    {
        CurrentBoxHealth -= damage;
        healthbar.setHealth(CurrentBoxHealth);
        Debug.Log("Current Box Health = " + CurrentBoxHealth);
        if (CurrentBoxHealth <= 0)
        {
            Debug.Log("BOOMBOX DESTROYED ... GAME OVER");
            SceneManager.LoadScene("MainMenu");
        }
        
        SFX.BoxHurtClip();
    }

    
}
