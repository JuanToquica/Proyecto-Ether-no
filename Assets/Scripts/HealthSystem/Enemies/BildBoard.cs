using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildBoard : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        // Busca autom�ticamente la c�mara principal
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("No se encontr� ninguna c�mara con el tag 'MainCamera'.");
        }
    }

    private void LateUpdate()
    {
        if (cam != null)
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}