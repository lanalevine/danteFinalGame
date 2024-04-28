using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{

    Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    public float Health {
        set {
            health = value;
            if(health<=0){
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1;

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }
      private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Hitbox"){
            
            Debug.Log("this is a test 3");
        
            Health-=1;

        }

         Debug.Log("this is a test 4");

    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
