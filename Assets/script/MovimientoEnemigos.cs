using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
    public float velocidad = 2f;
    public float escalon = 1f; // Distancia a bajar
    private int direccion = 1; // 1: derecha, -1: izquierda
    private float anchoEnemigo;
    private bool volteando = false; // Controla si está en proceso de animación
                                    //ControladorEnemigos.instance.DecrementarEnemigosRestantes();
    //public GameObject prefabPowerUp; // Prefab del power-up
    //public float probabilidadPowerUp = 0.8f; // Probabilidad de que salga un power-up (20%)


    void Start()
    {
        anchoEnemigo = GetComponent<MeshRenderer>().bounds.size.x / 2;
        // Iniciar la animación de volteo repetidamente
        InvokeRepeating(nameof(AnimarVolteo), 1f, 2f); // Cada 2 segundos

    }


    void Update()
    {
        // Restringir la posición en el eje Z
        transform.position = new Vector3(transform.position.x, transform.position.y, -367.85f);

        // Mover enemigo en el eje X
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        // Detectar colisión con los bordes de la cámara
        Vector3 posEnPantalla = Camera.main.WorldToViewportPoint(transform.position);
        if (posEnPantalla.x < 0 || posEnPantalla.x > 1)
        {
            ControladorEnemigos.instance.CambiarDireccionGlobal();
        }
       
    }
    // Método para incrementar la velocidad localmente


    public void CambiarDireccion(int nuevaDireccion)
    {
        direccion = nuevaDireccion;
    }

    public void BajarEscalon()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - escalon, transform.position.z);
    }



/*
    private void OnDestroy()
    {
        if (Random.value < probabilidadPowerUp)
        {
            // Instanciamos el power-up en la posición del objeto (enemigo)
            Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
        }
    }

    */

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