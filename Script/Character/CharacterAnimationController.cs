using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character; //Importando Scripts do Package da unity

public static class CharacterMovementAnimationKeys{ // Parametros da Unity

    public const string IsCrouching = "IsCrouching";
    public const string HorizontalSpeed =  "HorizontalSpeed";
    public const string VerticalSpeed = "VerticalSpeed";
    public const string IsGrounded = "IsGrounded";
    public const string Dead = "Dead";
    public const string IsAttacking = "IsAttacking";
    
}

public static class EnemyAnimationKeys{ 
    public const string IsChasing = "IsChasing";

}
public class CharacterAnimationController : MonoBehaviour
{
    
    private IDamageable damageable;
    protected Animator animator; //componente do Player
    protected CharacterMovement2D characterMovement; //Controle de movimentação do Player e do Enemy.
   
    
    protected virtual void Awake(){

        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
        damageable = GetComponent<IDamageable>();

       if(damageable != null){

            damageable.DeathEvent += OnDeath;

     }

    }
    
    private void OnDestroy(){

    if(damageable != null){
            
            damageable.DeathEvent -= OnDeath;
    
    }

  }

    private void OnDeath(){ //Toca animação de morte de Player e do Enemy

            animator.SetTrigger(CharacterMovementAnimationKeys.Dead);

    } 


    protected virtual void Update(){
       
            //animator.SetTrigger(CharacterMovementAnimationKeys.Dead);
            animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed); // Ativando Parametro de velocidade do Player. 1 e -1
        
    }






}
