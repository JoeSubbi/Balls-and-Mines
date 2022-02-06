using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealth : MonoBehaviour{
    public float health;
    public bool life;
    public HealthBar healthBar;

    void Start(){
        health = 3.0F;
        life = true;
        healthBar.SetMaxHealth(health);
        // GameObject.Find("Canvas/Health Bar")
        //     .GetComponent<HealthBar>()
        //     .SetMaxHealth(health);
    }

    void Update(){
        life = CheckLife();
        healthBar.SetHealth(health);
        // GameObject.Find("Canvas/Health Bar")
        //     .GetComponent<HealthBar>()
        //     .SetHealth(health);
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