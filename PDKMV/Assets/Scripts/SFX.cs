using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip ClickClip;


    public void PlayClip()
    {

        audioSource.clip = ClickClip;
        audioSource.Play();
    }


}
