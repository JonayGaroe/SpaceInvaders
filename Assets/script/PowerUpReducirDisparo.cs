using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpReducirDisparo : MonoBehaviour
{
    public float duration = 10f; // Duraci�n del PowerUp (en segundos)

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que colision� tiene el tag "Naves"
        if (other.CompareTag("Naves"))
        {
            // Intentamos obtener el componente DisparoBala del objeto que colision�
            DisparoBala disparoBalaScript = other.GetComponent<DisparoBala>();

            if (disparoBalaScript != null)
            {
                // Si el componente DisparoBala est� presente, activamos el PowerUp
                disparoBalaScript.ActivateSpeedBoost(duration); // Pasamos la duraci�n del PowerUp
                Debug.Log("PowerUp activado para: " + other.name + " con duraci�n de " + duration + " segundos.");
            }
            else
            {
                // Si el componente DisparoBala no est� presente, mostramos un mensaje de advertencia
                Debug.LogWarning("El componente DisparoBala no se encuentra en el objeto " + other.name);
            }

            // Destruir el PowerUp despu�s de que el jugador lo haya recogido
            Destroy(gameObject);
        }

    }
}