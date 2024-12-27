using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemigosScript : MonoBehaviour
{
    public static EnemigosScript instance;
    public GameObject[] prefabs; // Array para almacenar los diferentes prefabs (por ejemplo, suelos, paredes, etc.)
    public int anchoMapaMin = -1658; // Ancho del mapa
    public int anchoMapaMax = -1199; // Ancho del mapa
    public int altoMapaMin = 78; // Alto del mapa
    public int altoMapaMax = -54; // Alto del mapa

    public float distanciaEntreObjetosX = 30f; // Distancia entre cada prefab en el mapa
    public float distanciaEntreObjetosY = 20f; // Distancia entre cada prefab en el mapa
    public int filasEnemigo = 3;
    public int columnasEnemigo = 5;


    void Start()
    {

        GenerarEnemigos();

    }

    // Método para generar el mapa aleatorio
    public void GenerarEnemigos()
    {
        for (int filaEnemigos = 0; filaEnemigos < filasEnemigo; filaEnemigos++)
        {
            for (int columnaEnemigos = 0; columnaEnemigos < columnasEnemigo; columnaEnemigos++)
            {
                float posicionX = anchoMapaMin + columnaEnemigos * distanciaEntreObjetosX;
                float posicionY = altoMapaMin + filaEnemigos * distanciaEntreObjetosY;

                // Generar una posición aleatoria para el prefab
                Vector3 posicion = new Vector3(posicionX, posicionY, -380.8f);

                // Elegir un prefab aleatorio del array de prefabs
                GameObject prefabAleatorio = prefabs[Random.Range(0, prefabs.Length)];

                // Instanciar el prefab en la posición calculada
                Instantiate(prefabAleatorio, posicion, Quaternion.identity);
            }

        }

    }

}