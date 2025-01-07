using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupescudo : MonoBehaviour
{
   /*
        public float duracionEscudo = 10f; // Duración del escudo en segundos

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

                // Destruye el PowerUp después de que sea recogido
                Destroy(gameObject);
            }
        }

    public GameObject escudoVisual; // Referencia a un objeto visual para mostrar el escudo
    private bool tieneEscudo = false; // Si el jugador tiene escudo activo
    private float tiempoEscudoRestante = 0f;
    private void Update()
    {
        // Actualizar la duración del escudo
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
        // Ejemplo de cómo absorber daño
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (tieneEscudo)
            {
                Debug.Log("El escudo absorbió el daño.");
                return; // No tomar daño si el escudo está activo
            }

            Debug.Log("Daño recibido.");
            // Aquí puedes manejar el daño al jugador
        }
    }

    */


}
