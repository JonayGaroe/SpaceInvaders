using UnityEngine;
using TMPro;  // Aseg�rate de tener esta importaci�n para usar TextMeshPro

public class ContadorDeEnemigos : MonoBehaviour
{
    public TextMeshProUGUI enemigosText;  // Referencia al TextMeshPro para mostrar los enemigos restantes
    public int enemigosCount = 15;        // N�mero inicial de enemigos en la escena

    // Llamado al inicio del juego
    void Start()
    {
        // Aseg�raerse de que el contador de enemigos se muestre correctamente al principio
        ActualizarContador();
    }

    // M�todo para actualizar el contador en la UI
    public void ActualizarContador()
    {
        enemigosText.text = "Enemigos: " + enemigosCount.ToString();  // Actualizar el texto en la UI
    }

    // Este m�todo ser� llamado cuando un enemigo sea destruido
    public void ReducirEnemigos()
    {
        enemigosCount--;  // Decrementar el n�mero de enemigos
        ActualizarContador();  // Actualizar el texto en la UI

        if (enemigosCount <= 0)
        {
            // Si no quedan enemigos, podr�as activar el Canvas de victoria o cualquier otra acci�n
            //Debug.Log("�Todos los enemigos han sido derrotados!");
            // Aqu� podr�as llamar a tu funci�n de mostrar el Canvas de Ganador
            MenuDeOpciones.Instance.CanvasGanador();
        }
    }
}