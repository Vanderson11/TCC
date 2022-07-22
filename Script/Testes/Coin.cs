using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
     private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag == "Coin"){
            Destroy(collision.gameObject);
            UIController.UI.SetCoins();    
        }


     }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
