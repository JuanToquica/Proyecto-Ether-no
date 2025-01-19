using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocidadJugador;
    public float velocidad = 5f;
    public float velocityWithShield;
    public float normalVelocity = 5f;
    public float gravedad = -9.8f;
    public float alturaSalto = 3f;
    public float tiempoAgachado = 1f;
    public WeaponManager weaponManager;

    private bool IsGrounded;
    private bool agacharse = false;
    private bool lerpCrouch = false;
    private bool corriendo = false;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        IsGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            tiempoAgachado += Time.deltaTime;
            float p = tiempoAgachado / 1f;
            controller.height = Mathf.Lerp(controller.height, agacharse ? 1f : 2f, p);

            if (p >= 1f)
            {
                lerpCrouch = false;
                tiempoAgachado = 0f;
            }
        }
        if (weaponManager.isShieldDraw)
        {
            velocidad = velocityWithShield;
        }
        else
        {
            velocidad = normalVelocity;
        }
    }
    //Se reciben los inputs del input manager y se aplican al Character controller
    public void ProcessMoove(Vector2 input)
    {
        Vector3 direccionMovimiento = Vector3.zero;
        direccionMovimiento.x = input.x;// Movimiento lateral (izquierda-derecha)
        direccionMovimiento.z = input.y;// Movimiento hacia adelante-atrás
        controller.Move(transform.TransformDirection(direccionMovimiento) * velocidad * Time.deltaTime);
        velocidadJugador.y += gravedad * Time.deltaTime;
        if (IsGrounded &&  velocidadJugador.y < 0)
        {
            velocidadJugador.y = -2f;
        }
        controller.Move(velocidadJugador * Time.deltaTime);
    }
    public void Jump()
    {
        if (IsGrounded)
        {
            velocidadJugador.y = Mathf.Sqrt(alturaSalto * -3.0f * gravedad);
        }
        Debug.Log("saltando con: "+velocidadJugador.y);
    }

    public void Sprint(bool isSprinting)
    {
        if (!weaponManager.isShieldDraw)
        {
            corriendo = isSprinting;
            normalVelocity = corriendo ? 8f : 5f; // Cambia la velocidad dependiendo del estado de sprint
            Debug.Log("corriendo con velocidad: " + velocidad);
        }      
    }
    public void Crouch()
    {
        agacharse = !agacharse;
        tiempoAgachado = 0;
        lerpCrouch = true;
        Debug.Log("agachado: "+agacharse);
    }
}
