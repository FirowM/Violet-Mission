using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemiesInput
{   
    public override void EnemyDamageAttack()
    {
        if (CanAttack == false)
        {
            StartCoroutine(TryToAttack());

        }
    }
}
