using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneSound : MonoBehaviour
{
    public AudioSource audioSource;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SceneChangeWithPortal()
    {
        audioSource.Play();
    }
}
