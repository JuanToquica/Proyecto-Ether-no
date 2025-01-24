using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ChangeSceneScript changeScene;
    public Canvas canvas;

    private void Awake()
    {
        canvas.sortingOrder = 1;
    }
    public void jugar()
    {     
        changeScene.SceneChangeWithPortal();
        canvas.sortingOrder = 0;
    }

    public void salir()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }
}
