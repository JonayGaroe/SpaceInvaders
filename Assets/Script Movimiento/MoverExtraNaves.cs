using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

using static Unity.Burst.Intrinsics.X86;

public class MoverExtraNaves : MonoBehaviour
{


  
   
   

    // Las coordenadas a las que el cubo se moverá
    private float[] posicionesX = new float[] { -1747.5f, -1594.5f, -1431.2f };
    private float[] posicionesX2 = new float[] { -1431.2f, -1594.5f, -1747.5f };
    private float posicionY = 47.7f;  // Coordenada Y donde el cubo se moverá hacia arriba

    private int indicePosicion = 0;  // Mantener el índice de la posición actual

    public float tiempoMovimiento = 0.5f; // Tiempo de movimiento entre las posiciones

    void Update()
    {
        // Comprobar si se presiona la tecla 'D' para mover el cubo a la derecha
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoverCuboAProximaPosicion();
        }

        // Comprobar si se presiona la tecla 'A' para mover el cubo a la izquierda
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoverCuboAProximaPosicionAlrevez();
        }

      
    }

    // Función para mover el cubo a la siguiente posición en el eje X hacia la derecha
    void MoverCuboAProximaPosicion()
    {
        if (posicionesX.Length == 0) return; // Verifica que haya posiciones definidas

        // Si ya hemos recorrido todas las posiciones, reiniciamos el índice
        if (indicePosicion >= posicionesX.Length)
        {
            indicePosicion = 0; // Reiniciar a la primera posición
        }

        // Mover el cubo a la posición en el eje X
        LeanTween.moveX(gameObject, posicionesX[indicePosicion], tiempoMovimiento)
                 .setEase(LeanTweenType.easeInOutQuad);

        // Aumentar el índice para que apunte a la siguiente posición
        indicePosicion++;
    }

    // Función para mover el cubo a la siguiente posición en el eje X, pero en sentido contrario
    void MoverCuboAProximaPosicionAlrevez()
    {
        if (posicionesX2.Length == 0) return; // Verifica que haya posiciones definidas

        // Si ya hemos recorrido todas las posiciones, reiniciamos el índice
        if (indicePosicion >= posicionesX2.Length)
        {
            indicePosicion = 0; // Reiniciar a la primera posición
        }

        // Mover el cubo a la posición en el eje X en sentido contrario
        LeanTween.moveX(gameObject, posicionesX2[indicePosicion], tiempoMovimiento)
                 .setEase(LeanTweenType.easeInOutQuad);

        // Aumentar el índice para que apunte a la siguiente posición
        indicePosicion++;
    }

    // Función para mover el cubo hacia arriba en el eje Y
   








}














