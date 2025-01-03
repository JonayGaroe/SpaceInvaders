using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField]
    private float speed = 40f;
    [SerializeField]
    private float minX = -1774.3f;  // Límite mínimo en el eje X (por ejemplo, la pared izquierda)
    [SerializeField]
    private float maxX = -1392.286f;   // Límite máximo en el eje X (por ejemplo, la pared derecha)
    private bool controlesInvertidos = false; // Estado de inversión de controles
    public float boostedSpeed = 100f; // Velocidad aumentada durante el PowerUp
    private bool isBoosted = false; // Si el PowerUp está activo
    private float boostEndTime; // Momento en que termina el PowerUp
    private float currentSpeed; // Velocidad actual de la nave

    [SerializeField]
    GameObject Muro1, Muro2, Muro3, Muro4, Muro5, Muro6, Muro7, Muro8, Muro9, Muro10, Muro11, Muro12, Muro13, Muro14, Muro15, Muro16, Muro17, Muro18, Muro19, Muro20, Muro21, Muro22, Muro23, Muro24, Muro25;



    void Start()
    {
        

                currentSpeed = speed; // Al principio la nave tiene la velocidad normal




    }

    void Update()
    {
        // Obtener el movimiento horizontal
        float movement = Input.GetAxisRaw("Horizontal");

        // Invertir controles si están activados
        if (controlesInvertidos)
        {
            movement *= -1;
        }
        // Mover la nave
        float nuevaPosX = transform.position.x + movement * currentSpeed * Time.deltaTime;

        // Mover la nave
       // transform.Translate(Vector3.right * movement * currentSpeed * Time.deltaTime);
        // Limitar la nueva posición en X dentro de los límites especificados
        nuevaPosX = Mathf.Clamp(nuevaPosX, minX, maxX);

        // Actualizar la posición del jugador
        transform.position = new Vector3(nuevaPosX, transform.position.y, transform.position.z);






        // Comprobar si el boost de velocidad ha expirado
        if (isBoosted && Time.time > boostEndTime)
        {
            DeactivateSpeedBoost(); // Desactivar el boost de velocidad si el tiempo ha pasado
        }
    }






    // Método para invertir los controles durante un tiempo específico
    public void InvertirControles(float duracion)
    {
        controlesInvertidos = true; // Activar controles invertidos
        StartCoroutine(RestoreControles(duracion)); // Restaurar controles tras la duración
    }

    // Corrutina para restaurar los controles normales
    private IEnumerator RestoreControles(float duracion)
    {
        yield return new WaitForSeconds(duracion); // Esperar el tiempo especificado
        controlesInvertidos = false; // Restaurar controles normales
    }


    public void ActivateSpeedBoost(float duration)
    {
        if (!isBoosted)
        {
            isBoosted = true;
            currentSpeed = boostedSpeed; // Aumentamos la velocidad
            boostEndTime = Time.time + duration; // Establecemos el tiempo para desactivar el PowerUp
        }
    }

    private void DeactivateSpeedBoost()
    {
        isBoosted = false;
        currentSpeed = speed; // Restauramos la velocidad normal
    }




    private void OnTriggerEnter(Collider other)
    {







        if (other.CompareTag("PowerUp2")) // Detectar si el jugador toma el power-up
        {


            Muro1.SetActive(true);
            Muro2.SetActive(true);
            Muro3.SetActive(true);
            Muro4.SetActive(true);
            Muro5.SetActive(true);
            Muro6.SetActive(true);
            Muro7.SetActive(true);
            Muro8.SetActive(true);
            Muro9.SetActive(true);
            Muro10.SetActive(true);
            Muro11.SetActive(true);
            Muro12.SetActive(true);
            Muro13.SetActive(true);
            Muro14.SetActive(true);
            Muro15.SetActive(true);
            Muro16.SetActive(true);
            Muro17.SetActive(true);
            Muro18.SetActive(true);
            Muro19.SetActive(true);
            Muro20.SetActive(true);
            Muro21.SetActive(true);
            Muro22.SetActive(true);
            Muro23.SetActive(true);
            Muro24.SetActive(true);
            Muro25.SetActive(true);
            // Destruir el power-up
            Destroy(other.gameObject);


        }
    }
}