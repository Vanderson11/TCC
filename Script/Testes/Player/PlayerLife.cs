using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer2D.Character;

public class PlayerLife : MonoBehaviour
{
    public bool alive  = true;
    CharacterMovement2D playerMovement;

    public static PlayerLife pl;
    

    void Awake(){

      pl = this;

    }  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      UIController.UI.RefreshScreen();  
    }

    public void LoseLife(){ //Igual ao OnDeath

         if(alive){

            Debug.Log("Feito!");
            alive = false;
            //playerMovement.StopImmediately();
            //enabled = false;
            UIController.UI.SetLife(-1);    

         }   

    }

   
}
