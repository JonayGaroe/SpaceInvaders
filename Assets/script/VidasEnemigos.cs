using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasEnemigos : MonoBehaviour
{
    public int enemigosVida = 3;
    private ContadorDeEnemigos contador;  // Referencia al script ContadorDeEnemigos
    private bool enemigoMuerto = false; // Bandera para asegurarnos de que solo se llama una vez

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que el contador está correctamente asignado
        contador = FindObjectOfType<ContadorDeEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí podrías agregar cualquier lógica adicional si es necesario
    }

    private void OnCollisionEnter(Collision other)
    {
        // Verificar si el objeto que colisiona es una "Bala"
        if (other.gameObject.CompareTag("Bala"))
        {
            // Reducir la vida del enemigo
            enemigosVida--;

            // Verificar si el enemigo ha muerto
            if (enemigosVida <= 0 && !enemigoMuerto)
            {
                // Llamar a la función para reducir el contador de enemigos
                if (contador != null)
                {
                    contador.ReducirEnemigos();  // Reducir enemigos cuando este enemigo muere
                }

                // Marcar al enemigo como muerto para evitar que el código se ejecute varias veces
                enemigoMuerto = true;

                // Aquí podrías agregar cualquier acción adicional al morir (por ejemplo, destruir el objeto enemigo)
                Destroy(gameObject);  // Destruir el enemigo si tiene vida 0 o menos
            }
        }
    }
}