using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length; // Var de Armazenamento da largura do sprite do background.
    private float StartPos;  // Posição inicial;
    private Transform cam; // Controle da Camêra;


    public float ParallaxEffect;// Valor de efeito para cada elemento da Cena
    
    // Start is called before the first frame update
    void Start()
    { 
      StartPos = transform.position.x; //Declarando posição inicial para a var
      length = GetComponent<SpriteRenderer>().bounds.size.x; // Pegando a largura do Sprite no eixo X;  
      cam = Camera.main.transform; // Indicando quem é a camera na cena(Inicializando Camera)  
    }

    // Update is called once per frame
    void Update()
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect); // Reposionamento da camera antes de chegar ao fim do background
        float Distance = cam.transform.position.x * ParallaxEffect;
        
        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);

        if(RePos > StartPos + length){

          StartPos += length; //Reposicionando o background para x+;

        }else if(RePos < StartPos - length){
          StartPos -= length; // Reposicionando para x-;

        }
    }
}
