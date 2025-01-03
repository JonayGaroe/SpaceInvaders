using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControladorEnemigos1 : MonoBehaviour
{

    public static ControladorEnemigos1 instance; // Singleton para acceso global
    private int direccionGlobal = 1; // 1: derecha, -1: izquierda
    private int enemigosRestantes; // Para contar los enemigos activos

    public float velocidadBase = 2f; // Velocidad base de los enemigos
    public float multiplicadorVelocidad = 100f; // Factor por el cual se aumenta la velocidad cada vez que muere un enemigo

    private MovimientoEnemigos[] enemigosActivos; // Arreglo para almacenar los enemigos activos

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Inicializar los enemigos activos
            enemigosActivos = FindObjectsOfType<MovimientoEnemigos>();  // Solo lo hacemos una vez
        }
        else
        {
            Destroy(gameObject);
        }

        // Inicializar el contador de enemigos
        enemigosRestantes = enemigosActivos.Length;  // Inicializamos con el número de enemigos en la escena
    }

    public void CambiarDireccionGlobal()
    {
        // Cambiar la dirección global
        direccionGlobal *= -1;

        // Notificar a todos los enemigos que cambien de dirección y bajen el escalón
        foreach (MovimientoEnemigos enemigo in enemigosActivos)
        {
            enemigo.CambiarDireccion(direccionGlobal);
            enemigo.BajarEscalon();
        }
    }

    public void AjustarVelocidad()
    {
        // Ajustar la velocidad de los enemigos según la cantidad de enemigos restantes
        float velocidadAjustada = velocidadBase + (multiplicadorVelocidad / Mathf.Max(enemigosRestantes, 1));
        foreach (MovimientoEnemigos enemigo in enemigosActivos)
        {
            enemigo.velocidad = velocidadAjustada;
        }
    }

    public void DecrementarEnemigosRestantes()
    {
        // Aseguramos que solo decrementamos si hay enemigos restantes
        if (enemigosRestantes > 0)
        {
            enemigosRestantes--;  // Restar un enemigo

            // Aquí ajustamos la velocidad solo si hay enemigos restantes
            AjustarVelocidad();

            // Incrementar la velocidad de los enemigos restantes (si lo deseas)
            foreach (MovimientoEnemigos enemigo in enemigosActivos)
            {
                enemigo.IncrementarVelocidadLocal(20f); // Puedes ajustar el valor según lo desees
            }

            // Comprobar si ya no hay enemigos restantes
            if (enemigosRestantes <= 0)
            {
                // Acciones cuando todos los enemigos han sido eliminados, por ejemplo:
                Debug.Log("¡Todos los enemigos han sido derrotados!");
                // Puedes llamar aquí a cualquier otra función como CanvasGanador() o similar
            }
        }
    }
}