using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaExtra : MonoBehaviour
{

    public GameObject canvasEnemigo1;
    public GameObject canvasEnemigo2;
    public GameObject canvasEnemigo3;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colisión con objeto: {other.gameObject.name}, Tag: {other.gameObject.tag}");

        string tag = other.gameObject.tag;

        if (tag == "Enemigo1")
        {
            if (canvasEnemigo1 != null)
            {
                canvasEnemigo1.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("canvasEnemigo1 no está asignado en el Inspector.");
            }
        }
        else if (tag == "Enemigo2")
        {
            if (canvasEnemigo2 != null)
            {
                canvasEnemigo2.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("canvasEnemigo2 no está asignado en el Inspector.");
            }
        }
        else if (tag == "Enemigo3")
        {
            if (canvasEnemigo3 != null)
            {
                canvasEnemigo3.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("canvasEnemigo3 no está asignado en el Inspector.");
            }
        }
    }
}