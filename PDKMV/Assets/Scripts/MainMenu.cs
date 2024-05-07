using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CharacterMenu;
    public GameObject SongMenu;
    public void Play()
    {

        SceneManager.LoadScene("PDKMV"); // switch to main game
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void SelectFemale() {
        PlayerPrefs.SetInt("Sprite", 0);
        PlayerPrefs.Save();
        Debug.Log("Player will be female");

    }

    public void SelectMale() {
        PlayerPrefs.SetInt("Sprite", 1);
        PlayerPrefs.Save();
        Debug.Log("Player will be male");
    }

    public void SelectCharacter() {
    // Check if the player has played before
        if (!PlayerPrefs.HasKey("FirstTimePlayed"))
        {
            // Player is playing for the first time
            PlayerPrefs.SetInt("FirstTimePlayed", 1); // Set the flag indicating first-time play
            PlayerPrefs.Save(); // Save the PlayerPrefs

            // Activate the canvas
            if (CharacterMenu != null)
            {
                CharacterMenu.SetActive(true);
            }
        }
        else
{
    // Player has played before, deactivate the canvas
    if (CharacterMenu != null)
    {
        CharacterMenu.SetActive(false);
        SongMenu.SetActive(true);
    }
}
    }

    

   
}
