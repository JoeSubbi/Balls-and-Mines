using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Photon.Pun;

public class HamsterHealth : MonoBehaviourPunCallbacks
{
    public float health;
    public static bool life;
    public HealthBar healthBar;
    private GameObject healthBarObj;

    private GameObject gameMan;
    private GameManager gameManager;

    private float saturation = 20;

    void Awake(){
        if ((PhotonNetwork.IsConnected && photonView.IsMine) || !PhotonNetwork.IsConnected)
        {
            healthBarObj = GameObject.Find("Health Bar");
            healthBar = healthBarObj.GetComponent<HealthBar>();
            health = 3.0F;
            life = true;
            healthBar.SetMaxHealth(health);
        }
        
        gameMan = GameObject.Find("GameManager");
        
        gameManager = gameMan.GetComponent<GameManager>();

        

        Physics.IgnoreLayerCollision(16, 17, false);
        //     .GetComponent<HealthBar>()
        //     .SetMaxHealth(health);
    }

    void Update(){
        if ((PhotonNetwork.IsConnected && photonView.IsMine) || !PhotonNetwork.IsConnected)
        {
            life = CheckLife();
            healthBar.SetHealth(health);
        }
        // GameObject.Find("Canvas/Health Bar")
        //     .GetComponent<HealthBar>()
        //     .SetHealth(health);
    }

    bool CheckLife(){
        if (health <= 0.0F){
            if (PhotonNetwork.IsConnected)
            {
                gameManager.GameOverSelf(PhotonNetwork.LocalPlayer.NickName);
            }
            else
            {
                gameManager.GameOver();
            }
            
            saturation = Mathf.Lerp(saturation, -100, 0.01f);
            GameObject.Find("FX").GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.Override( saturation );
            Physics.IgnoreLayerCollision(16, 17, true);
            return false;
        } else {
            return true;
        }
    }

    public void decrementHealth(){
        health -= 1.0F;
    }
}