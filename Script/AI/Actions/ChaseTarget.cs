using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore; //Action
using Pada1.BBCore.Framework; //importando BaseprimitiveAction
using Pada1.BBCore.Tasks;
using Platformer2D.Character;

[Action("Game/ChaseTarget")]
public class ChaseTarget : BasePrimitiveAction
{
    [InParam("Target")]
    private GameObject target;  //objeto de perseguição do Enemy

    [InParam("AIController")]
    private EnemieAIController aIController; //Parametro de movimento do Enemy

    [InParam("ChaseSpeed")] //Velocidade de perseguir o target
    private float chaseSpeed;

    [InParam("CharacterMovement")] 
    private CharacterMovement2D characterMovement2D;

    public override void OnStart()
    {
        base.OnStart();
        aIController.IsChasing = true;
        characterMovement2D.MaxGroundSpeed = chaseSpeed;
    }

    public override void OnAbort()
    {
        base.OnAbort();
        aIController.IsChasing = false;
    }

    public override TaskStatus OnUpdate()
    {
        if(target == null){

           return TaskStatus.ABORTED;  

        }
        
        Vector2 toTarget = target.transform.position - aIController.transform.position; //Vetor de distancia do enemy.
        aIController.SetMovementInputX(Mathf.Sign(toTarget.x)); //Identificação de sinal do valor passado através da função

        return TaskStatus.RUNNING;
    }


}
