using UnityEngine;
using TMPro;  // Asegúrate de tener esta importación para usar TextMeshPro

public class ContadorDeEnemigos : MonoBehaviour
{
    public TextMeshProUGUI enemigosText;  // Referencia al TextMeshPro para mostrar los enemigos restantes
    public int enemigosCount = 15;        // Número inicial de enemigos en la escena

    // Llamado al inicio del juego
    void Start()
    {
        // Asegúraerse de que el contador de enemigos se muestre correctamente al principio
        ActualizarContador();
    }

    // Método para actualizar el contador en la UI
    public void ActualizarContador()
    {
        enemigosText.text = "Enemigos: " + enemigosCount.ToString();  // Actualizar el texto en la UI
    }

    // Este método será llamado cuando un enemigo sea destruido
    public void ReducirEnemigos()
    {
        enemigosCount--;  // Decrementar el número de enemigos
        ActualizarContador();  // Actualizar el texto en la UI

        if (enemigosCount <= 0)
        {
            // Si no quedan enemigos, podrías activar el Canvas de victoria o cualquier otra acción
            //Debug.Log("¡Todos los enemigos han sido derrotados!");
            // Aquí podrías llamar a tu función de mostrar el Canvas de Ganador
            MenuDeOpciones.Instance.CanvasGanador();
        }
    }
}