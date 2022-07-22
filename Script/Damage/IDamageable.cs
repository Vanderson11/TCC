using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage();
    void Damage(); 
    void Coin();

    event Action DeathEvent;
    bool IsDead{get;}
    
    
    
} 
