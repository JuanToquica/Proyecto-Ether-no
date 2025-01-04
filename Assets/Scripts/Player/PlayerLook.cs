using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivy = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //detectar la rotacion de la camara para mirar arriba y abajo
        xRotation -= (mouseY * Time.deltaTime) * ySensitivy;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //aplicar esto al transform de la camara del player
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //luego se rota al player a donde esta mirando
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
