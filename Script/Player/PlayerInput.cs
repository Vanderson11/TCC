using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
   private struct PlayerInputConstants{ // Agrupamento de dados

       public const string Horizontal = "Horizontal"; //Varivel que não muda o valor nunca mas pode ser acessada de fora.
       public const string Jump = "Jump"; 
       public const string Vertical = "Vertical";
       public const string Attack = "Attack";

   }
   
   public Vector2 GetMovementInput(){
       
       //Input Teclado
       float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);//Identificador Variavel que tem valor setado pela função padrão da unity.
       
       //Input Joystick
       if(Mathf.Approximately(horizontalInput, 0.0f)){

          horizontalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal); // Pegando o Input da Layer.

       }

       return new Vector2(horizontalInput, 0); // Retorna o sentido do movimento escolhido pelo player
   }

   public bool IsJumpButtonDown(){ // O botão de pulo esta para Baixo

       bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.Space);
       bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);
       
       return isKeyboardButtonDown || isMobileButtonDown;
       
   } 

   public bool IsJumpButtonHeld(){ //O botão de pulo Estiver acionado(Ajuste de Pulo).

       bool isKeyboardButtonHeld = Input.GetKey(KeyCode.Space);
       bool isMobileButtonHeld = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);

       return isKeyboardButtonHeld || isMobileButtonHeld;

   }

   public bool IsCrouchButtonDown(){

       bool iskeyboardButtonDown =  Input.GetKeyDown(KeyCode.S);
       bool isMobileButtonDown = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) < -0.5f;

       return iskeyboardButtonDown || isMobileButtonDown;

   }

    public bool IsCrouchButtonUp(){

        bool isKeyboardButtonUp = Input.GetKey(KeyCode.S) == false; //Verificando se a tecla está apertada
        bool isMobileButtonUp  = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) >= 0;
        
        return isKeyboardButtonUp && isMobileButtonUp;

    }

    public bool IsAttackButtonDown(){

        bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.K);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Attack);

        return isKeyboardButtonDown || isMobileButtonDown;

    }


}
