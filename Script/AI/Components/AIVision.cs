using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterFacing2D))]
public class AIVision : MonoBehaviour
{
    [Range(0.5f, 10.0f)]
    public float visionRange = 5; //Alcançe de visão do Enemy.

    [Range(0, 180)]
    public float visionAngle = 30; //Raio da visão

    private CharacterFacing2D characterFacing2D;

    private void Awake(){

        characterFacing2D = GetComponent<CharacterFacing2D>();

    }

    public bool IsVisible(GameObject target){ //Ver se o player esta dentro do raio de ação

        if(target == null){//Caso de um target vazio

            return false;

        }
        if(Vector2.Distance(transform.position , target.transform.position) > visionRange){ //Distancia até o target maior que o range de visão

            return false;

        }

        Vector2 toTarget = target.transform.position - transform.position;
        Vector2 visionDirection = GetVisionDirection(); //Componente de visão

        if(Vector2.Angle(visionDirection, toTarget) > visionAngle / 2){ //Fora do angulo de visão

            return false;

        } 

        return true; //ativando perseguição   
    }

    private void OnDrawGizmosSelected(){

        Gizmos.DrawWireSphere(transform.position, visionRange); //Desenhando o alcance da visão do Enemy.

        Vector3 visionDirection = GetVisionDirection();
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle/2) * visionDirection * visionRange); //Desenhando linha superior
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle/2) * visionDirection * visionRange);//Linha inferior
    }

    private Vector2 GetVisionDirection(){

        if(characterFacing2D == null){

            return Vector2.right;

        }
        
        return characterFacing2D.IsFacingRight() ? Vector2.right : Vector2.left;

    }
}
