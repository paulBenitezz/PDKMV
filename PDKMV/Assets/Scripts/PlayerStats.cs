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
    public Sprite MaleSprite;
    public Sprite FemaleSprite;
    public GameOver gameOver;
    SpriteRenderer CurrentSprite;
    

    void Awake() {
        CurrentPlayerHealth = MaxPlayerHealth;
    }
    void Start() {
        Debug.Log("Player Health = " + MaxPlayerHealth);
        healthbar.setMaxHealth(MaxPlayerHealth);
        CurrentSprite = GetComponent<SpriteRenderer>();
        SwapCharacter();


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
            gameOver.GameOverScreen("Player");
            // SceneManager.LoadScene("MainMenu");
        }

        if (isMale) {
            SFX.PlayerHurtMaleClip();
        }
        else {
            SFX.PlayerHurtFemaleClip();
        }
    }    


    public void SwapCharacter() {

        if (PlayerPrefs.GetInt("Sprite") == 1) {    // player selected male
            CurrentSprite.sprite = MaleSprite;
            isMale = true;
        }
        else if (PlayerPrefs.GetInt("Sprite") == 0) {   // player selected male
            CurrentSprite.sprite = FemaleSprite;
            isMale = false;
        }

        else {
            Debug.LogError("Sprite not selected");
        }
    }

    public void AddHealth(float health)
    {

        if (CurrentPlayerHealth != MaxPlayerHealth) 
        {
            CurrentPlayerHealth += health;
            healthbar.setHealth(CurrentPlayerHealth);
            
        }
        
    }
}
