using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {

        SceneManager.LoadScene("PDKMV"); // switch to main game
    }

    public void Quit()
    {
        Application.Quit();
    }

   
}
