using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]

    public GameObject dialogueBox;
    public TMP_Text speechText;

    [Header("Settings")]
    public float speedText; //Velocidade do Texto

 
    public void Speech(string txt){

        dialogueBox.SetActive(true);
        speechText.text = txt;
        Debug.Log("Ativando");

    }

    public void Next(){
        dialogueBox.SetActive(false);
    }



}   
