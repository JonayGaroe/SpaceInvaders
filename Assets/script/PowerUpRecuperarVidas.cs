using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRecuperarVidas : MonoBehaviour
{
    public int vidasRestauradas = 1; // Cantidad de vidas que se restaurar�n al jugador

    // Este m�todo se llamar� cuando el jugador toque el Power-Up
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Naves"))
        {
            // Recuperar todas las vidas del jugador
            VidasNaves playerVidas = other.GetComponent<VidasNaves>();
            if (playerVidas != null)
            {
                playerVidas.RestaurarVidas(vidasRestauradas);
            }

            // Desactivar el Power-Up despu�s de ser recogido
            gameObject.SetActive(false);
        }
    }
}
