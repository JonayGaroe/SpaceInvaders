using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class VidasNaves : MonoBehaviour
{

    [SerializeField]
    GameObject canvasPerder;
    [SerializeField]
    GameObject canvasPerderMenu;
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
  
    public void RestaurarVidas(int cantidadVidas)
    {
        vidas += cantidadVidas;
        Debug.Log("Vidas restauradas: " + vidas);
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
                canvasPerder.SetActive(true);
                LeanTween.alphaCanvas(canvasPerder.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar



                //  enemigosText.text = enemigosCount.ToString();
                //  enemigosText2.text = enemigosCount.ToString();




            }

        }

    }


    public void CanvasPerderReintentar()
    {






    }


    public void CanvasPerderNaves()
    {






    }





}