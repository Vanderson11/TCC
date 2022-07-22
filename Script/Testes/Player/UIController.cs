using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
 public static UIController UI;
 public TMP_Text coinsText;
 public int coins = 0;

 public TMP_Text lifeText;
 public int lives = 3;
 

 private void Awake(){

    RefreshScreen();

    if(UI == null){
        UI = this;
        DontDestroyOnLoad(gameObject); //Não destruir interface ao recarregar.
    }
    else if(UI != this){

        Destroy(gameObject);

    }

    
}

 public void SetLife(int life){

        lives += life;
        if(lives >= 0){
        RefreshScreen();
        }
      
    }

  public void SetCoins(){
       coins ++; 
       RefreshScreen();
  }  

 public void RefreshScreen(){ //Atualizar HUD

        lifeText.text = lives.ToString();
        coinsText.text = coins.ToString();

    } 

}
