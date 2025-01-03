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
        // Aseg�rate de que el contador est� correctamente asignado
        contador = FindObjectOfType<ContadorDeEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        // Aqu� podr�as agregar cualquier l�gica adicional si es necesario
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
                // Llamar a la funci�n para reducir el contador de enemigos
                if (contador != null)
                {
                    contador.ReducirEnemigos();  // Reducir enemigos cuando este enemigo muere
                }

                // Marcar al enemigo como muerto para evitar que el c�digo se ejecute varias veces
                enemigoMuerto = true;

                // Aqu� podr�as agregar cualquier acci�n adicional al morir (por ejemplo, destruir el objeto enemigo)
                Destroy(gameObject);  // Destruir el enemigo si tiene vida 0 o menos
            }
        }
    }
}