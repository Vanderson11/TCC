using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
  [SerializeField]
  [Min(-1)]
  private int damage;
  
 
  private void OnTriggerEnter2D(Collider2D collision){

   if(collision.gameObject.tag == "Chomper"){

      IDamageable damageable = collision.GetComponent<IDamageable>();
      if(damageable != null){

        damageable.Damage();
        
    }

   }

   if(collision.gameObject.tag == "Player"){
      
      IDamageable damageable = collision.GetComponent<IDamageable>();
      if(damageable != null){

        damageable.TakeDamage();
        
    }
   }

 
  } 
   
    
   /* IDamageable damageable = collision.GetComponent<IDamageable>();
    
    if(damageable != null){

        damageable.TakeDamage(damage);
        
    }*/

  }

