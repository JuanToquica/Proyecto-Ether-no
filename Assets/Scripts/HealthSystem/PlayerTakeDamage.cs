using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PlayerTakeDamage : MonoBehaviour
{
    public float intensity = 0f; // Variable pública para intensidad
    public Volume _volume;
    private Vignette _vignette;

    void Start()
    {
        // Busca el componente PostProcessVolume en el mismo GameObject
       if (_volume == null)
        {
            _volume = GetComponent<Volume>();
        }

        if (_volume.profile.TryGet(out _vignette))
        {
            _vignette.intensity.Override(0f); // Intensidad inicial
        }
        else
        {
            Debug.LogError("No se encontró el efecto Vignette en el perfil del Volume.");
        }
    }

    void Update()
    {
        // Simula un daño presionando el botón derecho del mouse
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(TakeDamageEffect());
        }
    }

    IEnumerator TakeDamageEffect()
    {
        Debug.Log("Inicio del efecto de daño.");
        float intensity = 0.4f; // Asegúrate de inicializar correctamente esta variable
        _vignette.intensity.Override(intensity);

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            Debug.Log($"Reduciendo intensidad: {intensity}");
            intensity -= 0.01f;
            if (intensity < 0) intensity = 0;

            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("Efecto de daño terminado.");
        yield break;
    }
}