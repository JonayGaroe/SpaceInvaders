using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuDeOpciones : MonoBehaviour
{
    public GameController gameController;
    // tiempo de la partida
    float tiempoDePartida = 0.0f;

    public static MenuDeOpciones Instance;  // Instancia estática del Singleton

    public GameObject canvasAjustes;
    public GameObject canvasOpciones;



    //Naves
    [SerializeField]
    GameObject nave1,nave2,nave3;




    // BASICO
    [SerializeField]
    GameObject canvasPlay;
  

    [SerializeField]
    GameObject canvasGanar;
    [SerializeField]
    GameObject canvasPerder;


    // texto de minutos ganar
    [SerializeField]
    TextMeshProUGUI tiempoganar;
    [SerializeField]
    TextMeshProUGUI tiempoperder;
    [SerializeField]
    TextMeshProUGUI tiempopartida;
    bool isPause;
 

    // Asegúrate de que el Singleton esté bien configurado en Awake()
    void Awake()
    {
        // Comprobar si la instancia es nula (significa que es la primera vez que se crea)
        if (Instance == null)
        {

            Instance = this;

            //DontDestroyOnLoad(gameObject);  // Si quieres que el objeto no se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruimos el nuevo objeto
        }

        gameController.ResetearPuntos();

    }




    void Start()
    {

        Time.timeScale = 1;




    }

    // Update is called once per frame
    void Update()
    {

        tiempoDePartida = tiempoDePartida + Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiamos el estado de la pausa
            isPause = !isPause;

            if (isPause)
            {
                // Activamos el estado de pausa
                Time.timeScale = 0; // Pausa el juego

                // Activamos el Canvas de opciones
                canvasOpciones.SetActive(true);

                // Animación para mostrar el Canvas de opciones
                LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true);
            }
            else
            {
                // Desactivamos el estado de pausa
                Time.timeScale = 1; // Reanuda el juego

                // Animación para desvanecer el Canvas de opciones
                LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() =>
                {
                    // Desactivamos el Canvas de opciones después de la animación
                    canvasOpciones.SetActive(false);
                }).setIgnoreTimeScale(true);
            }


            /*
            if (tiempoperder == true)
            {

                isPause = true;



            }


            */

        }


  
        float minutos = Mathf.FloorToInt(tiempoDePartida / 60F);
        float segundos = Mathf.FloorToInt(tiempoDePartida % 60F);
        tiempopartida.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        tiempoganar.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        tiempoperder.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        // tiempopartida.text = tiempoDePartida.ToString();
        //tiempoganar.text = string.Format("{0:00}:{1:00}", minutos, segundos);






    }



    public void BotonPlay()
    {

        canvasOpciones.SetActive(false);
        Time.timeScale = 1;
        float minutos = Mathf.FloorToInt(tiempoDePartida / 60F);
        float segundos = Mathf.FloorToInt(tiempoDePartida % 60F);
        tiempopartida.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        tiempopartida.text = tiempoDePartida.ToString();


    }




    public void BotonAjustes()
    {
        // Detener el tiempo del juego
        Time.timeScale = 0;

        // Animación para desvanecer el canvasOpciones
        LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() =>
        {
            canvasOpciones.SetActive(false); // Desactivamos después de la animación
        }).setIgnoreTimeScale(true); // Ignora la escala del tiempo

        // Activamos canvasAjustes y animamos la opacidad
        canvasAjustes.SetActive(true);
        LeanTween.alphaCanvas(canvasAjustes.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar
    }

    public void BotonSalir()
    {
        // Detener el tiempo del juego
        Time.timeScale = 0;

        // Animación para desvanecer el canvasAjustes
        LeanTween.alphaCanvas(canvasAjustes.GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() =>
        {
            canvasAjustes.SetActive(false); // Desactivamos después de la animación
        }).setIgnoreTimeScale(true); // Ignora la escala del tiempo

        // Activamos canvasOpciones y animamos la opacidad
        canvasOpciones.SetActive(true);
        LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void CanvasGanador()
    {

        tiempopartida.text = tiempoganar.text;

        canvasGanar.SetActive(true);
        LeanTween.alphaCanvas(canvasAjustes.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar
      //  float minutos = Mathf.FloorToInt(tiempoDePartida / 60F);
        //float segundos = Mathf.FloorToInt(tiempoDePartida % 60F);
       // tiempoganar.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        Time.timeScale = 0;
        // tiempoganar.text = tiempoDePartida.ToString();
        //Time.timeScale = 0;
       // float minutos = Mathf.FloorToInt(tiempoDePartida / 60F);
      //  float segundos = Mathf.FloorToInt(tiempoDePartida % 60F);
       //tiempoganar.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        //Time.timeScale = 0;



    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Elegir1"))
        {


           nave1.SetActive(true);
            LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar
            Destroy(gameObject);




        }
        if (other.gameObject.CompareTag("Elegir2"))
        {




            nave2.SetActive(true);
            LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar
            Destroy(gameObject);







        }

        if (other.gameObject.CompareTag("Elegir3"))
        {






            nave3.SetActive(true);
            LeanTween.alphaCanvas(canvasOpciones.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true); // 0.5 segundos para animar
            Destroy(gameObject);






        }






    }


    public void CancelarNave()
    {
        // Animación para desvanecer el canvasAjustes
        
            nave1.SetActive(false);
            nave2.SetActive(false);
            nave3.SetActive(false);
            // Desactivamos después de la animación
      
    }




    public void ElegirNave1()
    {

        SceneManager.LoadScene("Nave1");
        gameController.ResetearPuntos();


    }



    public void ElegirNave2()
    {
      
        SceneManager.LoadScene("Nave2");
        gameController.ResetearPuntos();



    }


    public void ElegirNave3()
    {

        SceneManager.LoadScene("Nave3");
        

    }

    public void ElegirNavesNormal()
    {

        SceneManager.LoadScene("EleccionDeNaves");


    }


    public void Next3()
    {
        gameController.NextLevel();
        SceneManager.LoadScene("Nave3");


    }


}