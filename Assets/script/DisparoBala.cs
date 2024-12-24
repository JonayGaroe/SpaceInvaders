using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBala : MonoBehaviour
{
    public GameObject prefabBala; // Prefab de la bala
    public Transform puntoDisparo; // Punto desde donde se disparará la bala
    public float velocidadBala = 60f; // Velocidad a la que la bala se mueve
    public float tiempoDeVida = 2f; // Tiempo en segundos antes de destruir la bala


    // Start is called before the first frame update
    void Start()
    {



        





    }

    // Update is called once per frame
    void Update()
    {

        // Detectar si se presiona el botón (por ejemplo, la tecla Espacio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }






    }


    void Disparar()
    {
        // Instanciar la bala en el punto de disparo con la rotación predeterminada
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);

        // Aplicar movimiento hacia arriba
    
            Rigidbody rb3D = bala.GetComponent<Rigidbody>(); // Si es 3D
            if (rb3D != null)
            {
                rb3D.velocity = Vector3.up * velocidadBala;
            }

        



    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



}
