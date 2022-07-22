using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character; //Importando


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))] //Requisição de Componente
[RequireComponent(typeof(IDamageable))]
public class EnemieAIController : MonoBehaviour
{
   
    IDamageable damageable;
    CharacterMovement2D enemyMovement;
    Vector2 movementInput; //Input de movimentação do Enemy
    CharacterFacing2D enemyFacing; 
    bool isChasing;

    public bool IsChasing{

        get => isChasing; 
        set => isChasing = value;    

    }   

     [SerializeField]
     private TriggerDamage damager;



   /* public Vector2 MovementInput{

        get{ return movementInput;}
        set{ movementInput = new Vector2(Mathf.Clamp(value.x, -1, 1), Mathf.Clamp(value.y, -1, 1) ); }
    }*/

    public void SetMovementInputX(float x){

        movementInput.x = Mathf.Clamp(x, -1, 1); //Estipulando um Range para o valor
   
    }

    void Start()
    {
        enemyFacing = GetComponent<CharacterFacing2D>();
        enemyMovement = GetComponent<CharacterMovement2D>();
        
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDeath;
        
    }

    private void OnDestroy(){
        if(damageable != null){

            damageable.DeathEvent -= OnDeath;

        }
    }

    // Update is called once per frame
    void Update()
    {
       enemyMovement.ProcessMovementInput(movementInput);
       enemyFacing.UpdateFacing(movementInput); 
        
    }

   

    

    private void OnDeath(){

       
        enabled = false;
        enemyMovement.StopImmediately();
        damager.gameObject.SetActive(false);
        Destroy(gameObject, 0.6f);
      
      } 
       
}

    
 
    


