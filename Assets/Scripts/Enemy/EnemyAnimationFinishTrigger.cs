using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationFinishTrigger : MonoBehaviour
{
    private Enemy enemy => GetComponentInParent<Enemy>();

    void AnimationTrigger(){
        enemy.AnimationTrigger();
    }

    private void AttackTrigger(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckDistance);

        foreach (Collider2D collider in colliders){
            if(collider.GetComponent<Player>()!=null){
                collider.GetComponent<Player>().Damage();
            }
        }
    }

    private void OpenCounterWindow(){
        enemy.OpenCounterAttackWindow();
    }

    private void CloseCounterWindow(){
        enemy.CloseCounterAttackWindow();
    }



}
