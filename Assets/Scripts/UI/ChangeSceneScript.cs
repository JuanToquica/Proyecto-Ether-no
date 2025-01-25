using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ChangeSceneScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Image flash;
    public float flashSpeed = 1.1f;
    public Canvas canvas;
    private Coroutine activeCoroutine;

    private void Awake()
    {
        flash.color = new Color(1, 1, 1, 0);
        canvas.sortingOrder = 0;
    }


    public void SceneChangeWithPortal()
    {
        StartCoroutine(FlashAndChangeScene());
    }

    private IEnumerator FlashAndChangeScene()
    {
        canvas.sortingOrder = 2;
        audioSource.Play();

        for (float alpha = 0; alpha <= 1; alpha += Time.unscaledDeltaTime * flashSpeed)
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
        flash.color = new Color(1, 1, 1, 0);
        canvas.sortingOrder = 0;
    }
}