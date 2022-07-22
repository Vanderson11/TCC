using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : TriggerDamage, IWeapon
{
    [SerializeField]
    private float attackTime = 0.2f; // Controla o tempo do attack

    public bool IsAttacking { get; private set;}//Todos podem acessar mais somente a gente pode setar os valores

    private void Awake(){

        gameObject.SetActive(false); //Desabilitando o Weapon
        IsAttacking = false;

    }
    
    public void Attack(){

        if(!IsAttacking){ //Resolvendo o bug de atacar mais de uma vez seguidas vezes
            
            gameObject.SetActive(true);
            IsAttacking = true;
            StartCoroutine(PerformAttack());
        
        }

    } 

    private IEnumerator PerformAttack(){

        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
        IsAttacking = false;

    }
}
