using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip ClickClip;

    public AudioClip PlayerHurtMale;
    public AudioClip PlayerHurtFemale;
    public AudioClip Heal;
    public AudioClip Fix;
    public AudioClip shot;
    public AudioClip[] BoxHurt;


    public void PlayClip()
    {

        audioSource.clip = ClickClip;
        audioSource.Play();
    }

    public void PlayerHurtMaleClip() {
        audioSource.clip = PlayerHurtMale;
        audioSource.Play();
    }
    public void PlayerHurtFemaleClip()
    {
        audioSource.clip = PlayerHurtFemale;
        audioSource.Play();
    }
    public void BoxHurtClip()
    {
        int rand = Random.Range(0, BoxHurt.Length);
        audioSource.clip = BoxHurt[rand];
        audioSource.Play();
    }

    public void PlayerHeal()
    {
        audioSource.clip = Heal;
        audioSource.Play();
    }
    public void BoxHeal()
    {
        audioSource.clip = Fix;
        audioSource.Play();
    }

    public void WeaponShot()
    {
        audioSource.clip = shot;
        audioSource.Play();
    }

}
