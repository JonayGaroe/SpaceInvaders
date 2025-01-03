using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class GameObjecEnemigos : MonoBehaviour
{

    
    public Canvas canvasGanar;



    public AudioClip Bloquefx;


    // contador
    public TextMeshProUGUI enemigosText;
    public int enemigosCount = 15;

    public static GameObjecEnemigos instance;
    // puntos enemigos 
    public int puntos = 10; // Puntos que otorga este enemigo cuando es destruido
    public int puntosdobles = 20; // Puntos que otorga este enemigo cuando es destruido


    private bool puntosDoblesActivos = false; // Si los puntos dobles están activos
    private float tiempoRestante = 0f; // Tiempo restante de los puntos dobles


    public TextMeshProUGUI enemigosText2;
    public GameObject prefabPowerUp; // Prefab del power-up
    public float probabilidadPowerUp = 0.8f; // Probabilidad de que salga un power-up (20%)
    public GameObject prefabPowerUp2; // Prefab del power-up
    public float probabilidadPowerUp2 = 0.8f; // Probabilidad de que salga un power-up (20%)
    public GameObject prefabPowerUp3; // Prefab del power-up
    public float probabilidadPowerUp3 = 0.8f; // Probabilidad de que salga un power-up (20%)
    public GameObject prefabPowerUp4; // Prefab del power-up
    public float probabilidadPowerUp4 = 0.8f; // Probabilidad de que salga un power-up (20%)
    public GameObject prefabPowerUp5; // Prefab del power-up
    public float probabilidadPowerUp5 = 0.8f; // Probabilidad de que salga un power-up (20%)
    public GameObject prefabPowerUp6; // Prefab del power-up
    public float probabilidadPowerUp6 = 0.8f; // Probabilidad de que salga un power-up (20%)






    // Start is called before the first frame update
    void Start()
    {
        //MenuDeOpciones.Instance.CanvasGanador();  // Acceder a la función de MenuDeOpciones

        enemigosCount = 15;
       // enemigosText.text = enemigosCount.ToString(); // Mostrar el contador en la interfaz

    }

    // Update is called once per frame
    void Update()
    {

        // Si los puntos dobles están activos, reducir el tiempo restante
        if (puntosDoblesActivos)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                // Desactivar puntos dobles cuando se acabe el tiempo
                puntosDoblesActivos = false;
            }
        }

       




    }
    // Método para activar los puntos dobles durante un tiempo específico
    public void ActivarPuntosDobles(float duracion)
    {
        puntosDoblesActivos = true;
        tiempoRestante = duracion;
    }

    // Método para agregar puntos
    public void SumarPuntos(int cantidad)
    {
        if (puntosDoblesActivos)
        {
            puntos *= 2; // Duplicar los puntos si están activos
            GameController.instance.AgregarPuntos(puntosdobles);
        }

        puntos += cantidad;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemigos"))
        {
            // Verificar si el tag coincide antes de hacer el resto de la lógica
            // Destruir el objeto con el tag "bloquesss"
            other.collider.GetComponent<VidasEnemigos>().enemigosVida -= 1;
            Destroy(gameObject);
         
            AudioSource.PlayClipAtPoint(Bloquefx, transform.position);

            GameController.instance.AgregarPuntos(puntos); // Añadir puntos al controlador de puntuación
            if (other.collider.GetComponent<VidasEnemigos>().enemigosVida <= 0)
            {
                enemigosCount = enemigosCount - 1;
                Debug.Log("menos 1 enemigo");
                if (enemigosCount <= 0)
                {
            
                    MenuDeOpciones.Instance.CanvasGanador();
                    Debug.Log("Todos los enemigos han sido derrotados.");
                }
                Debug.Log("muerto");

                Destroy(other.gameObject);                //enemigosCount--;
                GameController.instance.AgregarPuntos(puntosdobles); // Añadir puntos al controlador de puntuación
                // enemigosText2.text = enemigosCount.ToString();

                if (Random.value < probabilidadPowerUp3)
                {
                    // Instanciamos el power-up en la posición del objeto (enemigo)
                    Instantiate(prefabPowerUp3, transform.position, Quaternion.identity);
                }

                //  enemigosText.text = enemigosCount.ToString();
                //  enemigosText2.text = enemigosCount.ToString();
                if (Random.value < probabilidadPowerUp)
                {
                    // Instanciamos el power-up en la posición del objeto (enemigo)
                    Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
                }
                if (Random.value < probabilidadPowerUp2)
                {
                    // Instanciamos el power-up en la posición del objeto (enemigo)
                    Instantiate(prefabPowerUp2, transform.position, Quaternion.identity);
                }

                if (Random.value < probabilidadPowerUp4)
                {
                    // Instanciamos el power-up en la posición del objeto (enemigo)
                    Instantiate(prefabPowerUp4, transform.position, Quaternion.identity);
                }
                if (Random.value < probabilidadPowerUp5)
                {
                    // Instanciamos el power-up en la posición del objeto (enemigo)
                    Instantiate(prefabPowerUp5, transform.position, Quaternion.identity);
                }
                if (Random.value < probabilidadPowerUp6)
                {
                    // Instanciamos el power-up en la posición del objeto (enemigo)
                    Instantiate(prefabPowerUp6, transform.position, Quaternion.identity);
                }

            }

        }
        //Asegurarnos de que la colisión es con un objeto con el tag correcto
        //if (other.CompareTag("bloquesss")
        // Verificar si el tag coincide antes de hacer el resto de la lógica
        // Destruir el objeto con el tag "bloquesss"

        



    }
}