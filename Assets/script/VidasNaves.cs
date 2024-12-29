using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class VidasNaves : MonoBehaviour
{


    public int vidas = 3;
    public TextMeshProUGUI vidasText;


    // Start is called before the first frame update
    void Start()
    {
        




    }

    // Update is called once per frame
    void Update()
    {

        vidasText.text = "" + vidas;



    }


    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("BalaEnemigos"))
        {

           
            vidas--;
            Debug.Log("Vidas restantes: " + vidas);
            Destroy(other.gameObject);

            if (vidas <= 0)  
            {
       
                Time.timeScale = 0;




                //  enemigosText.text = enemigosCount.ToString();
                //  enemigosText2.text = enemigosCount.ToString();




            }

        }

    }
}