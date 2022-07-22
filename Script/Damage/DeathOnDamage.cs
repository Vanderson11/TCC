using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathOnDamage : MonoBehaviour, IDamageable
{
    public bool IsDead {get; private set;}

    public event Action DeathEvent;

    
    
    private void Awake(){

       IsDead = false;   

    }

    public void TakeDamage()
    {
        
        
        if(UIController.UI.lives > 0 ){
        
        UIController.UI.SetLife(-1); 
        Debug.Log("Acertando!");
        
        }else if(UIController.UI.lives == 0){
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            UIController.UI.lives = 0;
            IsDead = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;  
           
        }
         
        //Destroy(gameObject);
    }

    public void Damage()
    {
       DeathEvent.Invoke(); 
    }

    public void Coin()
    {
        UIController.UI.SetCoins();
    }
}
