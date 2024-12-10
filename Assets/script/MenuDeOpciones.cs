using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDeOpciones : MonoBehaviour
{

    [SerializeField]    
    GameObject canvasOpciones;


    [SerializeField]
    GameObject canvasPlay;

    [SerializeField]
    GameObject canvasSalir;


    bool isPause;
    void Start()
    {

        Time.timeScale = 0;




    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            isPause = !isPause;

            if (isPause == true)
            {

                Time.timeScale = 0;
             canvasOpciones.SetActive(true);

            }

            if (isPause == false)
            {

                Time.timeScale = 1;
                canvasOpciones.SetActive(false);



            }





        }

    }



    public void BotonPlay()
    {

        canvasOpciones.SetActive(false);
        Time.timeScale = 1;







    }










    public void Exit()
    {


        Application.Quit();


    }



}
