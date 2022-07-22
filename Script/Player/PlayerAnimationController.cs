using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : CharacterAnimationController
{
  
  private PlayerController player;

  protected override void Awake(){

     base.Awake();
     player = GetComponent<PlayerController>();
    
  } 

 
   public void Death(){

      animator.SetTrigger(CharacterMovementAnimationKeys.Dead);
      
   }
  
  protected override void Update(){
     
     base.Update();
     animator.SetBool(CharacterMovementAnimationKeys.IsCrouching, characterMovement.IsCrouching); //Ativa o parametro da animação.
     animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);   // Rodando a animação de pulo. 
     animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, characterMovement.IsGrounded); //Ativando animação do pulo   
     animator.SetBool(CharacterMovementAnimationKeys.IsAttacking, player.weapon.IsAttacking); 

  }

  
}