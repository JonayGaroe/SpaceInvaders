using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBalaEnemigo : MonoBehaviour
{
    public GameObject prefabBala; // Prefab de la bala
    public Transform puntoDisparo; // Punto desde donde se disparará la bala
    public float velocidadBala = 60f; // Velocidad a la que la bala se mueve
    public float intervaloDisparo = 5f; // Tiempo entre disparos

    public float distanciaDeteccion = 800f; // Distancia del raycast

    public LayerMask capaEnemigos; // Capa asignada a los enemigos

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DispararCada5Segundos());
    }

    IEnumerator DispararCada5Segundos()
    {
        while (true)
        {
            if (!HayEnemigoDebajo())
            {
                Disparar();
              
            }
            else
            {
                Debug.Log("No se detectó ningún enemigo debajo.");
            }
            yield return new WaitForSeconds(intervaloDisparo);
          
        }
    }




    bool HayEnemigoDebajo()
    {
        Debug.Log("No se detectó ningún enemigo debajo.");

        Debug.DrawRay(transform.position, Vector3.down * distanciaDeteccion, Color.red, 1f);
        RaycastHit hit3D; // Declarar la variable para almacenar el impacto
        bool hayImpacto = Physics.Raycast(transform.position, Vector3.down, out hit3D, distanciaDeteccion, capaEnemigos);
   


        if (hayImpacto)
        {
            Debug.Log("Enemigo detectado debajo: " + hit3D.collider.gameObject.name);
            return true; // Hay un enemigo debajo
   
        }

        return false; // No hay enemigo debajo
   
    }

    //while (true)
    //Un bucle while que ejecuta su contenido mientras la condición sea verdadera.
    //En este caso, la condición es true, lo que significa que este bucle se ejecutará infinitamente hasta que se detenga manualmente.






    // Update is called once per frame
    void Update()
    {
        // Incrementar el temporizador
       // temporizador += Time.deltaTime;

        // Verificar si han pasado los 5 segundos
      //  if (temporizador >= intervaloDisparo)
       // {
        //    Disparar(); // Llamar al método Disparar
          //  temporizador = 0f; // Reiniciar el temporizador



        }


    void Disparar()
    {
        // Instanciar la bala en el punto de disparo con la rotación predeterminada
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);

        // Aplicar movimiento hacia arriba

        Rigidbody rb3D = bala.GetComponent<Rigidbody>(); // Si es 3D
        if (rb3D != null)
        {

            rb3D.velocity = Vector3.down * velocidadBala;


        }





    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
