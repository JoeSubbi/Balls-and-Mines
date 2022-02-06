using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HamsterHealth : MonoBehaviour{
    public float health;
    public static bool life;
    public HealthBar healthBar;
    public GameObject gameOver;

    private float saturation = 20;

    void Awake(){
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
            life = false;
            gameOver.SetActive(true);
            saturation = Mathf.Lerp(saturation, -100, 0.01f);
            GameObject.Find("FX").GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.Override( saturation );
            return false;
        } else {
            return true;
        }
    }

    public void decrementHealth(){
        health -= 1.0F;
    }
}