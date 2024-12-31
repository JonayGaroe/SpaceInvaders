using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAunmentoVelocidad : MonoBehaviour
{
    public float duration = 10f; // Duración del PowerUp en segundos
   //public float boostedSpeed = 20f; // Velocidad aumentada durante el PowerUp
    // Este método será llamado cuando el jugador recoja el power-up
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que colisionó tiene el tag "Player"
        if (other.CompareTag("Naves"))
        {
            // Llamamos al script del jugador y aumentamos su velocidad
            MovimientoJugador playerMovement = other.GetComponent<MovimientoJugador>();
            if (playerMovement != null)
            {
                playerMovement.ActivateSpeedBoost(duration); // Aumentar velocidad
               
            }
          
            // Destruir el PowerUp después de que el jugador lo haya recogido
            Destroy(gameObject);
        }
    }
}