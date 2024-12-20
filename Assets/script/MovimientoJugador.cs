using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField]
    private float speed = 40f;
    [SerializeField]
    private float minX = -1774.3f;  // L�mite m�nimo en el eje X (por ejemplo, la pared izquierda)
    [SerializeField]
    private float maxX = -1392.286f;   // L�mite m�ximo en el eje X (por ejemplo, la pared derecha)


    void Start()
    {
        





    }

    void Update()
    {

        // Obtener el movimiento horizontal
        float movement = Input.GetAxisRaw("Horizontal");

        // Calcular la nueva posici�n en el eje X
        float newPosX = transform.position.x + movement * speed * Time.deltaTime;

        // Limitar la posici�n en el eje X para que no traspase las paredes
        newPosX = Mathf.Clamp(newPosX, minX, maxX);


        // Asignar la nueva posici�n manteniendo la posici�n Y igual
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);



        //float movement = Input.GetAxisRaw("Horizontal");
        // transform.position += new Vector3(movement, 0 * speed * Time.deltaTime);





    }




}
