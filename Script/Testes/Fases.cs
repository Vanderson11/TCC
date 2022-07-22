using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fases : MonoBehaviour
{
    public string cena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void Fase1(){

        SceneManager.LoadScene(cena); // Carregar cena desejada
    
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag == "Fase2"){
            Destroy(collision.gameObject);
            SceneManager.LoadScene("TelaFinalPhase1");

               
        }

        if(collision.gameObject.tag == "Fase3"){
            Destroy(collision.gameObject);
            SceneManager.LoadScene("TelaFinal");
               
        }


     }

}