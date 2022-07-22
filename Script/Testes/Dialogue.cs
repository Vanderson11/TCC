using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string speechText;

    private DialogueControl dialogueControl;
    public LayerMask playerLayer ;
    public float radius;

    private void Start(){

        dialogueControl = FindObjectOfType<DialogueControl>(); // Buscar o dialoguecontrol

    }

    private void FixedUpdate(){

        Interact();    

    }

    //public ContactFilter2D contactFilter = new ContactFilter2D();contactFilter.layerMask
    public void Interact(){
        
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
                         
                         
        if(hit != null){

            dialogueControl.Speech(speechText);

        }else{
            Debug.Log("TEste");
        }

    }

    private void OnDrawGizmosSelected(){

        Gizmos.DrawWireSphere(transform.position, radius);

    }


}
