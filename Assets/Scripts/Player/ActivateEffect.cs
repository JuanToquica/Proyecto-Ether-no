using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEffect : MonoBehaviour
{
    public ParticleSystem efecto;

    public void ExecuteSlash()
    {
        efecto.Play();
    }
}
