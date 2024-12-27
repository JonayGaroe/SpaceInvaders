using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
 
    public static ControladorEnemigos instance; // Singleton para acceso global
    private int direccionGlobal = 1; // 1: derecha, -1: izquierda

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CambiarDireccionGlobal()
    {
        // Cambiar la direcci�n global
        direccionGlobal *= -1;

        // Notificar a todos los enemigos que cambien de direcci�n y bajen el escal�n
        MovimientoEnemigos[] enemigos = FindObjectsOfType<MovimientoEnemigos>();
        foreach (MovimientoEnemigos enemigo in enemigos)
        {
            enemigo.CambiarDireccion(direccionGlobal);
            enemigo.BajarEscalon();
        }
    }
}
