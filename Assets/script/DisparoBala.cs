using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBala : MonoBehaviour
{
    //float horizontalInput = Input.GetAxis("Horizontal");


    //float verticalInput = Input.GetAxis("Vertical");
   //&& Input.GetButton("Jump") || Input.GetKeyDown(KeyCode.Space))

    public GameObject prefabBala; // Prefab de la bala
    public Transform puntoDisparo; // Punto desde donde se disparará la bala
    public GameObject objetocreado; // Prefab de la bala

    public GameObject prefabbalaEspecial; // Prefab de la bala
    public GameObject prefabbalaEspecial2; // Prefab de la bala

    public float velocidadBala = 60f; // Velocidad a la que la bala se mueve
    public float tiempoDeVida = 2f; // Tiempo antes de destruir la bala

    // Variables para controlar el tiempo entre disparos
    public float tiempoEntreDisparosNormal = 1f; // Tiempo entre disparos normal (1 segundo)
    private float tiempoEntreDisparosActual; // Tiempo actual entre disparos
    private float tiempoSiguienteDisparo = 0f; // Tiempo del siguiente disparo

    // Tiempo de retardo para disparar (en segundos)
    public float retardoDisparo = 0f; // 0 segundos de retardo por defecto

    // Variable para almacenar el momento en que termina el PowerUp
    private float tiempoPowerUpFin = 0f;

    // Indicador de si el PowerUp está activo
    private bool powerUpActivo = false;

    void Start()
    {

         
        
        // Inicializamos el tiempo entre disparos al valor normal
        tiempoEntreDisparosActual = tiempoEntreDisparosNormal;
         
    }

    void Update()
    {

       
        powerUpActivo = !powerUpActivo;

        // Si el PowerUp ha expirado, restauramos el tiempo de disparo normal
        if (powerUpActivo && Time.time >= tiempoPowerUpFin)
        {
            RestaurarTiempoDisparo();
        }
        if(/*Time.time >= tiempoSiguienteDisparo &&*/ Input.GetKeyDown(KeyCode.L))
        {

            Disparar2();


        }

        // Detectar si se presiona la tecla de disparo (Espacio)

        if (Time.time >= tiempoSiguienteDisparo && Input.GetButton("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                Disparar(); // Llamar al método de disparo
                tiempoSiguienteDisparo = Time.time + tiempoEntreDisparosActual + retardoDisparo; // Establecer el siguiente tiempo de disparo
            }
    }
   

    void Disparar2()
    {

        GameObject bala = Instantiate(prefabbalaEspecial, transform.position, Quaternion.identity);

        // Aplicar movimiento hacia arriba
        Rigidbody rb3D = bala.GetComponent<Rigidbody>(); // Si es 3D
        if (rb3D != null)
        {
            rb3D.velocity = Vector3.up * velocidadBala;
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
   
    // Método para activar el PowerUp de disparo
    public void ActivateSpeedBoost(float duration)
    {
        if (!powerUpActivo)
        {
            powerUpActivo = true;
            tiempoEntreDisparosActual = 0.1f; // Reducimos el tiempo entre disparos a 0.1 segundos
            tiempoPowerUpFin = Time.time + duration; // Establecer cuándo termina el PowerUp
            Debug.Log("PowerUp activado. Tiempo entre disparos reducido a " + tiempoEntreDisparosActual);
        }
    }

    // Método para restaurar el tiempo entre disparos al valor normal
    private void RestaurarTiempoDisparo()
    {
        powerUpActivo = false;
        tiempoEntreDisparosActual = tiempoEntreDisparosNormal; // Restaurar el tiempo entre disparos original
       // Debug.Log("PowerUp terminado. Tiempo entre disparos restaurado a " + tiempoEntreDisparosActual); para restaurar tiempo
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BalaEspecial"))
        {


            Instantiate(prefabbalaEspecial2, transform.position, Quaternion.identity);
          //prefabbalaEspecial2.SetActive(false);
            Debug.Log("instancia hecha");


        }





    }





    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destruir el objeto cuando ya no sea visible
    }

   


}