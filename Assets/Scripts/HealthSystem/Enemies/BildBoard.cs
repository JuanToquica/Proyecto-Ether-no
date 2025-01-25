using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildBoard : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        // Busca automáticamente la cámara principal
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ninguna cámara con el tag 'MainCamera'.");
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