using System.Collections;
using System.Collections.Generic;
using Pada1.BBCore; //Action
using Pada1.BBCore.Framework; //importando BaseprimitiveAction
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using UnityEngine;

[Action("Game/Patrol")] //Para Ver essa action no editor da BehaviorTree
public class Patrol : BasePrimitiveAction
{
    [InParam("AIController")]
    private EnemieAIController aIController; //Parametro de Acesso Externo para funcionar função 
    
    
    [InParam("PatrolSpeed")] //Velocidade de patrulha do Enemy
    private float patrolSpeed;

    [InParam("CharacterMovement")] 
    private CharacterMovement2D characterMovement2D;

    public override void OnStart()
    {
        base.OnStart();
        aIController.StartCoroutine(Temp_Walk());
        characterMovement2D.MaxGroundSpeed = patrolSpeed;

    }

    public override TaskStatus OnUpdate()
    {
        
        return TaskStatus.RUNNING; //Deixar as ações rodando sempre.
    }

    public override void OnAbort()
    {
        base.OnAbort();

        //TODO remover corrotine
        aIController.StopAllCoroutines();
    }

    IEnumerator Temp_Walk(){

        while(true){
            aIController.SetMovementInputX(1);
            yield return new WaitForSeconds(1.0f);
            aIController.SetMovementInputX(0);
            yield return new WaitForSeconds(1.0f);
            aIController.SetMovementInputX(-1);
            yield return new WaitForSeconds(1.0f);

        }
    }

}
