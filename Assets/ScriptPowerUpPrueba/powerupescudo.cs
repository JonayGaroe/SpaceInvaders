using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupescudo : MonoBehaviour
{
   /*
        public float duracionEscudo = 10f; // Duraci�n del escudo en segundos

        private void OnTriggerEnter(Collider other)
        {
            // Verifica si el objeto que colisiona es el jugador
            if (other.CompareTag("Player"))
            {
                // Busca el componente del jugador que controla el escudo
                MovimientoJugador jugador = other.GetComponent<MovimientoJugador>();
                if (jugador != null)
                {
                    jugador.ActivarEscudo(duracionEscudo); // Activa el escudo
                }

                // Destruye el PowerUp despu�s de que sea recogido
                Destroy(gameObject);
            }
        }

    public GameObject escudoVisual; // Referencia a un objeto visual para mostrar el escudo
    private bool tieneEscudo = false; // Si el jugador tiene escudo activo
    private float tiempoEscudoRestante = 0f;
    private void Update()
    {
        // Actualizar la duraci�n del escudo
        if (tieneEscudo)
        {
            tiempoEscudoRestante -= Time.deltaTime;
            if (tiempoEscudoRestante <= 0)
            {
                DesactivarEscudo();
            }
        }


         public void ActivarEscudo(float duracion)
    {
        tieneEscudo = true;
        tiempoEscudoRestante = duracion;

        // Mostrar el escudo visual si existe
        if (escudoVisual != null)
        {
            escudoVisual.SetActive(true);
        }
    }

    public void DesactivarEscudo()
    {
        tieneEscudo = false;

        // Ocultar el escudo visual si existe
        if (escudoVisual != null)
        {
            escudoVisual.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ejemplo de c�mo absorber da�o
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (tieneEscudo)
            {
                Debug.Log("El escudo absorbi� el da�o.");
                return; // No tomar da�o si el escudo est� activo
            }

            Debug.Log("Da�o recibido.");
            // Aqu� puedes manejar el da�o al jugador
        }
    }

    */


}
