using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDePruebas : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject carlos;
    [SerializeField]
    LeanTweenType pablo;

    void Start()
    {
        
      
        
        LeanTween.scaleY(carlos, 1, 1f).setEase(pablo).setOnComplete(() =>
        {


            LeanTween.scaleY(carlos, 1, 1f).setEase(pablo).setOnComplete(() =>
            {



                LeanTween.scaleY(carlos, 1, 1f).setEase(pablo).setOnComplete(() =>
                {



                });

            });



        });
    

    }

    // Update is called once per frame
    void Update()
    {
        
       

    }




}
