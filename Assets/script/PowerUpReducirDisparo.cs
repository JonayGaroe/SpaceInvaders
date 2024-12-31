using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpReducirDisparo : MonoBehaviour
{
    public float duration = 10f; // Duración del PowerUp (en segundos)

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que colisionó tiene el tag "Naves"
        if (other.CompareTag("Naves"))
        {
            // Intentamos obtener el componente DisparoBala del objeto que colisionó
            DisparoBala disparoBalaScript = other.GetComponent<DisparoBala>();

            if (disparoBalaScript != null)
            {
                // Si el componente DisparoBala está presente, activamos el PowerUp
                disparoBalaScript.ActivateSpeedBoost(duration); // Pasamos la duración del PowerUp
                Debug.Log("PowerUp activado para: " + other.name + " con duración de " + duration + " segundos.");
            }
            else
            {
                // Si el componente DisparoBala no está presente, mostramos un mensaje de advertencia
                Debug.LogWarning("El componente DisparoBala no se encuentra en el objeto " + other.name);
            }

            // Destruir el PowerUp después de que el jugador lo haya recogido
            Destroy(gameObject);
        }

    }
}