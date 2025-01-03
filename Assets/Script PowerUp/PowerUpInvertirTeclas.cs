using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvertirTeclas : MonoBehaviour
{
    public float duracionInversion = 7f; // Duraci�n del efecto en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Naves")) // Detectar si el jugador toma el power-up
        {
            // Acceder al script de control del jugador
            MovimientoJugador controlJugador = other.GetComponent<MovimientoJugador>();
            if (controlJugador != null)
            {
                // Invertir controles
                controlJugador.InvertirControles(duracionInversion);

                // Destruir el power-up
                Destroy(gameObject);
            }
        }
    }
}
