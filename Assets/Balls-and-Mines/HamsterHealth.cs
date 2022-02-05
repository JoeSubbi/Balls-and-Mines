using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealth : MonoBehaviour{
    public float health;
    public bool life;

    void Start(){
        health = 3.0F;
        life = true;
    }

    void Update(){
        life = CheckLife();
    }

    bool CheckLife(){
        if (health <= 0.0F){
            Debug.Log("HAMMY NOOOOO");
            return false;
        } else {
            return true;
        }
    }

    public void decrementHealth(){
        health -= 1.0F;
    }
}