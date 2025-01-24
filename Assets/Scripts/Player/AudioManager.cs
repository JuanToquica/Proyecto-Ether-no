using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioSource pasosSound;
    public WeaponManager weaponManager;
    public PlayerMotor playerMotor;

    public AudioClip shootClip;
    public AudioClip reloadClip;
    public AudioClip Bolillaso;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Update()
    {
        if (weaponManager.isShieldDraw)
        {
            pasosSound.pitch = 1;
        }
        else if (!weaponManager.isShieldDraw && !playerMotor.corriendo)
        {
            pasosSound.pitch = 1.5f;
        }
        else if (playerMotor.corriendo)
        {
            pasosSound.pitch = 2;
        }
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void StartStepSound()
    {
        if (!pasosSound.isPlaying)
        {
            pasosSound.Play();
        }
    }
    public void StopStepSound()
    {
        pasosSound.Stop();
    }

}
