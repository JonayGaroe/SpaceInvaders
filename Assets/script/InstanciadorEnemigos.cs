using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorEnemigos : MonoBehaviour
{

    public GameObject prefabEnemigo; // Prefab del enemigo
    public Transform puntoInicio; // Punto de inicio del enemigo
    public float tiempoInstanciacion = 5f; // Tiempo entre instanciaciones

    public float velocidad = 5f; // Velocidad de movimiento del enemigo
    public int puntosPorMatar = 70; // Puntos que otorga al destruirlo
    public Vector3 limiteSalida; // Coordenadas donde el enemigo sale de la cámara



    private float timer = 0f; // Temporizador para la instanciación

    // Start is called before the first frame update
    void Start()
    {
        // Inicialización, si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Sumar el tiempo transcurrido en cada frame
        timer += Time.deltaTime;

        // Si han pasado los 15 segundos, instanciar el enemigo
        if (timer >= tiempoInstanciacion)
        {
            InstanciarEnemigo();
            timer = 0f; // Reiniciar el temporizador
        }

        // Mover al enemigo de izquierda a derecha
        transform.position -= Vector3.right * velocidad * Time.deltaTime;

        // Si el enemigo sale de la cámara, destruirlo
        if (transform.position.x < limiteSalida.x)
        {
            Destroy(gameObject);
        }
    }

    void InstanciarEnemigo()
    {
        // Instanciar al enemigo en el punto de inicio
        Instantiate(prefabEnemigo, puntoInicio.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bala")) // Si colisiona con un proyectil del jugador
        {
            Destroy(gameObject); // Destruir al enemigo
            GameController.instance.AgregarPuntos(puntosPorMatar); // Añadir puntos al sistema de puntuación
            Destroy(other.gameObject); // Destruir el proyectil
        }
    }


}
