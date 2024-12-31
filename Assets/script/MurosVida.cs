using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurosVida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        // Este objeto se ocultará cuando colisione con cualquier otro objeto
        gameObject.SetActive(false);
        Destroy(other.gameObject);
    }

}