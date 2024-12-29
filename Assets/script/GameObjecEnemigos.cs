using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class GameObjecEnemigos : MonoBehaviour
{
    public int enemigosCount = 15;
    public TextMeshProUGUI enemigosText;
    public TextMeshProUGUI enemigosText2;



    // Start is called before the first frame update
    void Start()
    {
        enemigosCount = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemigos"))
        {
            // Verificar si el tag coincide antes de hacer el resto de la lógica
            // Destruir el objeto con el tag "bloquesss"
            other.collider.GetComponent<VidasEnemigos>().enemigosVida -= 1;
            Destroy(gameObject);

            if (other.collider.GetComponent<VidasEnemigos>().enemigosVida <= 0)
            {
                Destroy(other.gameObject);         
                enemigosCount = enemigosCount - 1;
                //enemigosText.text = enemigosCount.ToString();
               // enemigosText2.text = enemigosCount.ToString();



                //  enemigosText.text = enemigosCount.ToString();
                //  enemigosText2.text = enemigosCount.ToString();




            }

        }


        //Asegurarnos de que la colisión es con un objeto con el tag correcto
        //if (other.CompareTag("bloquesss"))

        // Verificar si el tag coincide antes de hacer el resto de la lógica
        // Destruir el objeto con el tag "bloquesss"
    }
}