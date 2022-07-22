using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;//Herança de classe.
using UnityEngine.UI;

[RequireComponent(typeof(CharacterMovement2D))] // Componente necessario para o funcionamento do Script
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterFacing2D))]
[RequireComponent(typeof(IDamageable))]

public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    PlayerInput playerInput;
    CharacterFacing2D playerFacing; // Direção do Sprite
    IDamageable damageable;

    [SerializeField] GameObject weaponObject; 
    public IWeapon weapon{ get; private set;} //Variavel de interface
   

    [Header("Camera")]
    [SerializeField]
    Transform cameraTarget; //Objeto criado na unity dentro do Player
    [Range(0.0f, 5.0f)]
    [SerializeField]
    float cameraTargetOffsetX; // Controle de distancia do objeto no eixo X
    [Range(0.5f, 50.0f)]
    [SerializeField]
    float cameraTargetFlipSpeed;
    [Range(0.0f, 5.0f)]
    [SerializeField]
    public float characterSpeedInfluence;

    void Start()
    {
     playerMovement = GetComponent<CharacterMovement2D>(); //Função que pega um componente dentro do objeto em questão.
     playerInput = GetComponent<PlayerInput>();
     playerFacing = GetComponent<CharacterFacing2D>();
     
     
     
     damageable = GetComponent<IDamageable>();
     //damageable.DeathEvent += OnDeath;  //Inscrevendo se no Evento 
    
     if(weaponObject != null){

        weapon = weaponObject.GetComponent<IWeapon>(); //Inicializando objeto Weapon

     }

    }

    // Update is called once per frame
    void Update()
    {
      //Movimentação do Player
      
      Vector2 movementInput = playerInput.GetMovementInput(); // Nova variavel para receber as funções de playerInput
      playerMovement.ProcessMovementInput(movementInput); //Linha responsavel pela movimentação do objeto


      //Mudar direção da sprite do Jogador
      
      playerFacing.UpdateFacing(movementInput);
      
      // Pulo do Player

      if(playerInput.IsJumpButtonDown()){  //Se a tecla definida estiver sendo pressionada faça

          playerMovement.Jump(); //Chamando a função pulo do CharacterMovement2D

      } 

      if(playerInput.IsJumpButtonHeld() == false){//Caso o botão não esteja sendo mais apertado

          playerMovement.UpdateJumpAbort(); 
      } 

      // Função de agachar do Player

      if(playerInput.IsCrouchButtonDown()){

        playerMovement.Crouch();

      

      } else if(playerInput.IsCrouchButtonUp()){

        playerMovement.UnCrouch();

      }

      // Attack do Player

      if(weapon != null && playerInput.IsAttackButtonDown()){

       weapon.Attack();

      } 


    }



    private void FixedUpdate(){
    
      // Objeto CameraTarget do Player(Controle de posição de camera)
      
      bool isFacingRight = playerFacing.IsFacingRight(); //Se estiver para direta o sprite.
      float targetOffsetX = isFacingRight ? cameraTargetOffsetX : -cameraTargetOffsetX; // if e else reduzido se verdade 1 condição se não 2 condição

      float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed); //Suavização da traca de sentido da camera
      
      currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence; // Acrescentar um pouco de velocidade ao objeto
      
      
      cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.y); // Setando posição da camera 
     // 

    }

    /*private void OnDestroy(){

      if(damageable != null){
        damageable.DeathEvent -= OnDeath; //Se des inscrever do Evento.
      }
    }*/
    
    

    /*private void OnDeath(){

      if(lives < 1){

      
      Debug.Log("fim");
      }
      else{
        Debug.Log("Testando");
        TesteLife(-1);
        Debug.Log(lives);

      }
      
       
    }*/
}
