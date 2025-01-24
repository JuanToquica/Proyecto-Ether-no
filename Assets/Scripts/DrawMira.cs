using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMira : MonoBehaviour
{
    public Image mira;


    public void JuegoPausado()
    {
        Color colorActual = mira.color;
        colorActual.a = 0;
        mira.color =  colorActual;
    }

    public void JuegoDespausado()
    {
        Color colorActual = mira.color;
        colorActual.a = 1;
        mira.color = colorActual;
    }


}
