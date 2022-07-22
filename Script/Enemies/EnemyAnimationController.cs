using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : CharacterAnimationController
{
     EnemieAIController aIController;

     protected override void Awake(){

        base.Awake();
        aIController = GetComponent<EnemieAIController>();
     }
    
    protected override void Update()
    {
      base.Update();
      animator.SetBool(EnemyAnimationKeys.IsChasing, aIController.IsChasing); //ativando o parametro de perseguir o player      
    }
}
