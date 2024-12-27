using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
    public float velocidad = 2f;
    public float escalon = 1f; // Distancia a bajar
    private int direccion = 1; // 1: derecha, -1: izquierda
    private float anchoEnemigo;
    private bool volteando = false; // Controla si est� en proceso de animaci�n
    //ControladorEnemigos.instance.DecrementarEnemigosRestantes();



    void Start()
    {
        anchoEnemigo = GetComponent<MeshRenderer>().bounds.size.x / 2;

        // Iniciar la animaci�n de volteo repetidamente
        InvokeRepeating(nameof(AnimarVolteo), 1f, 2f); // Cada 2 segundos
    }


    void Update()
    {
        // Mover enemigo en el eje X
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        // Detectar colisi�n con los bordes de la c�mara
        Vector3 posEnPantalla = Camera.main.WorldToViewportPoint(transform.position);
        if (posEnPantalla.x < 0 || posEnPantalla.x > 1)
        {
            // Notificar al controlador
            ControladorEnemigos.instance.CambiarDireccionGlobal();
        }

    }

    public void CambiarDireccion(int nuevaDireccion)
    {
        direccion = nuevaDireccion;
    }

    public void BajarEscalon()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - escalon, transform.position.z);
    }

    void AnimarVolteo()
    {
        if (!volteando)
        {
            volteando = true;

            // Rotar 180 grados en el eje Y
            LeanTween.rotateY(gameObject, 180f, 0.2f).setOnComplete(() =>
            {
      
                // Rotar de vuelta a 0 grados en el eje Y
                LeanTween.rotateY(gameObject, 0f, 0.2f).setOnComplete(() =>
                {
                    volteando = false;
                });
            });
        }
    }
}