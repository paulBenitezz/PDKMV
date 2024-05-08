using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip GameOverSong;
    public GameObject GameOverObject;
    public TextMeshProUGUI tmp;
    GameLoader gl;

    public void Start() 
    {
        
        gl = GetComponent<GameLoader>();
    }
    public void Restart() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOverScreen(String thing) {
        audioSource.clip = GameOverSong;
        Time.timeScale = 0;
        audioSource.Play();

        if (thing.Equals("Player")) {
            tmp.text = "GAME OVER\nPLAYER DIED\nTHEY KILLED YOUR VIBE\n:(";
        }
        else if (thing.Equals("Boombox")) {
            tmp.text = "GAME OVER\nBOOMBOX DESTROYED\nTHEY KILLED YOUR VIBE\n:(";
        }
        Debug.Log("Death Screen audioclip: " + audioSource.clip);

        GameOverObject.SetActive(true);
    }
}
