using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{

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
        Destroy(gameObject);
    }
}
