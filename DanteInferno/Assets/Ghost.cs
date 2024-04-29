using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

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

    public bool Reaped {
        set {
            reaped = value;
            if(reaped){
                Reaping();
                Debug.Log("test 1");
            }
            else{
                Debug.Log("test 2");
            }
        }
        get {
            return reaped;
        }
    }

    public float health = 1;
    public bool reaped = false;

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void Reaping(){
        animator.SetTrigger("Reaping");
    }


    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
