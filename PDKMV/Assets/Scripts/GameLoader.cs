using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] songs;
    private int selectedSongIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlaySelectedSong();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying || Input.GetKeyDown(KeyCode.RightArrow)) {
            SwitchSongs();
        }   
    }

    public void PlaySelectedSong()
    {
        if (PlayerPrefs.HasKey("SelectedSongIndex"))
        {
            // Get the selected song index from PlayerPrefs
            selectedSongIndex = PlayerPrefs.GetInt("SelectedSongIndex");
            Debug.Log(selectedSongIndex);
            // Assign the selected song to the AudioSource component
            audioSource.clip = songs[selectedSongIndex];
            audioSource.Play();
            Debug.Log("Now Playing: " + audioSource.clip);
        }
        else
        {
            Debug.LogWarning("No song selected.");
        }
    }

    public void SwitchSongs() {
        selectedSongIndex++;

        if (selectedSongIndex >= songs.Length) {
            selectedSongIndex = 0;
        }

        audioSource.clip = songs[selectedSongIndex];
        audioSource.Play();
        Debug.Log("Now Playing: " + audioSource.clip);
    }   
}
