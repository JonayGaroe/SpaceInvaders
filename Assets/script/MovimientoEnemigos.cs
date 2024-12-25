using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
    public float velocidad = 2f;
    public float escalon = 1f; // Distancia a bajar
    private int direccion = 1; // 1: derecha, -1: izquierda
    private float anchoEnemigo;

    void Start()
    {
        anchoEnemigo = GetComponent<MeshRenderer>().bounds.size.x / 2;
    }

    void Update()
    {
        // Mover enemigo en el eje X
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        // Detectar colisión con los bordes de la cámara
        Vector3 posEnPantalla = Camera.main.WorldToViewportPoint(transform.position);
        if (posEnPantalla.x < 0 || posEnPantalla.x > 1)
        {
            CambiarDireccion();
        }

    }

    void CambiarDireccion()
    {
        // Cambiar dirección
        direccion *= -1;

        // Bajar un escalón
        transform.position = new Vector3(transform.position.x, transform.position.y - escalon, transform.position.z);
    }



}