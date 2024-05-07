using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider MasterSlider;




    private void Start() 
    {
        if (PlayerPrefs.HasKey("MusicVolume")) {
            LoadVolume();
        } 
        else {

            SetMusicVolume();
            SetSFXVolume();
            SetMasterVolume();
        }
    }

    public void SetMusicVolume() 
    {

        float volume = MusicSlider.value;
        mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume()
    {

        float volume = SFXSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetMasterVolume()
    {

        float volume = MasterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    private void LoadVolume() 
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }

}
