using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] songs;
    private int selectedSongIndex = 0;
    [SerializeField] TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        PlaySelectedSong();
        StartCoroutine(PrintSongs(3f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying || Input.GetKeyDown(KeyCode.RightArrow)) {
            SwitchSongs();
            StartCoroutine(PrintSongs(5f));
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

    IEnumerator PrintSongs(float duration) {

        AudioClip clip = audioSource.clip;
        if (clip != null) {
            Debug.Log("Now Playing: " + audioSource.clip);
            tmp.text = "Now Playing: " + clip.name;
            yield return new WaitForSeconds(duration);
            tmp.text = string.Empty;
        }

        else {
            Debug.LogWarning("AudioClip is null.");
        }
    }
}