using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;
    public DrawMira mira;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                Reanudar();
            else
                Pausar();
        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
        mira.JuegoDespausado();
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
        mira.JuegoPausado();
    }

    public void Reiniciar()
    {
        menuPausa.SetActive(false);
        Scene escenaActual = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(escenaActual.name);
        Time.timeScale = 1f;
        juegoPausado = false;
        mira.JuegoDespausado();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        juegoPausado = false;
    }
}