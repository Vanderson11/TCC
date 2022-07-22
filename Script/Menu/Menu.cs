using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena; //Recebe o nome da Cena que será carregada
    public GameObject creditsPanel; // Recebe o objeto Panel do editor

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame(){

        //Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;

        //jogo Compilado
        Application.Quit();

    }

    
    public void StartGame(){

        SceneManager.LoadScene(cena); // Carregar cena desejada

    }

    public void CreditsPanel(){

        creditsPanel.SetActive(true);

    }

    public void BackToMenu(){

       creditsPanel.SetActive(false); 
    
    }
}
