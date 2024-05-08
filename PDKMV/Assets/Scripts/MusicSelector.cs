using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicSelector : MonoBehaviour
{

    public AudioSource audioSource;

    // Array of AudioClip to hold your songs
    public AudioClip[] songs;
    

    // Method to handle button click event
    public void OnSongSelectButtonClicked(int songIndex)
    {
        // Assign the selected song to the AudioSource component
        // audioSource.clip = songs[songIndex];
        PlayerPrefs.SetInt("SelectedSongIndex", songIndex);
        PlayerPrefs.Save();
        Debug.Log("Song Selected: " + songs[songIndex]);
    
    }

    
}
