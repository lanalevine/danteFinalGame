using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Reap: MonoBehaviour
{   
    public Collider2D reapCollider;
    Vector2 rightReapOffset;
    
   private void Start(){
    rightReapOffset = transform.position;

   }

  
   public void ReapRight() {
    reapCollider.enabled = true;
    transform.localPosition = rightReapOffset;
   }

   public void ReapLeft() {
    reapCollider.enabled = true;
    transform.localPosition = new Vector3(rightReapOffset.x * -1, rightReapOffset.y);

   }

   public void StopReap(){
    Debug.Log("Testtt");
    reapCollider.enabled = false;
   }

  private void OnTriggerEnter2D(Collider2D item){
        if(item.tag == "Ghost"){

            Ghost ghost = item.GetComponent<Ghost>();
            Debug.Log("test 3");

            
            if(ghost!=null){
                ghost.Reaped = true;
                Debug.Log("test 4");

            }
        }
    }

}
