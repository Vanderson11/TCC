using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore; //Action
using Pada1.BBCore.Framework; //importando BaseprimitiveAction
using Pada1.BBCore.Tasks;
using BBUnity.Conditions;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private GameObject target; //Referencia ao player

    [InParam("AIVision")]
    private AIVision aIVision;

    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;

    private float forgetTargetTime;
    
    public override bool Check()
    {
        bool isAvailable = IsAvailable();
        if(aIVision.IsVisible(target) && isAvailable){

            forgetTargetTime = Time.time + targetMemoryDuration; //Criando memoria para o Enemy.
            return true;
        }
        return Time.time < forgetTargetTime && isAvailable; //Se naõ tiver chegado no tempo futuro continua a perseguir. Delay
        
        //return aIVision.IsVisible(target);
        //return Vector2.Distance(gameObject.transform.position, target.transform.position) < 3; //Calculo da distancia do enemy e do Player e condição de ação.    
       
    }

    private bool IsAvailable(){

        if(target == null){

            return false;

        }

        IDamageable damageable = target.GetComponent<IDamageable>();
        if(damageable != null){

           return !damageable.IsDead;     

        }

        return true;
            
    }
}
