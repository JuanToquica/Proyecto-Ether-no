using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Image flash;
    public float flashSpeed = 1.1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void SceneChangeWithPortal()
    {       
        StartCoroutine(FlashAndChangeScene());
    }

    private IEnumerator FlashAndChangeScene()
    {
        audioSource.Play();
        for (float alpha = 0; alpha <= 1; alpha += Time.deltaTime * flashSpeed)
        {
            flash.color = new Color(1, 1, 1, alpha);
            yield return null;
        }       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        for (float alpha = 1; alpha >= 0; alpha -= Time.deltaTime * flashSpeed)
        {
            flash.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        flash.color = new Color(1, 1, 1,0);
    }
}
