using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SwordAttack : MonoBehaviour
{   
    public float damage = 3;
    public Collider2D swordCollider;
    Vector2 rightAttackOffset;

   private void Start(){
    rightAttackOffset = transform.position;
   }

  
   public  void AttackRight() {
    swordCollider.enabled = true;
    transform.localPosition = rightAttackOffset;
   }

   public void AttackLeft() {
    swordCollider.enabled = true;
    transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);

   }

   public void StopAttack(){
    swordCollider.enabled = false;
   }

  private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ghost"){

            Ghost ghost = other.GetComponent<Ghost>();

            if(ghost!=null){
            //attack
                  ghost.Health -= damage;     
            }
        }
    }

}
