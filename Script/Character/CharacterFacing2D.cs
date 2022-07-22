using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFacing2D : MonoBehaviour
{
    
    SpriteRenderer spriteRenderer; //Todos que forem usar esse Script precisam de Sprite.

    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFacing(Vector2 movementInput){ //Update de pra onde esta olhando
        
    if(movementInput.x > 0){
            
        spriteRenderer.flipX = false;

    }else if(movementInput.x < 0){

        spriteRenderer.flipX = true;

      }
    }

    public bool IsFacingRight(){

        return spriteRenderer.flipX == false;
    
    }
}
