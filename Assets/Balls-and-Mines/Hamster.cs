using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Hamster : MonoBehaviourPunCallbacks
{
    public GameManager gameManager;
    public GameObject camera;
    private CameraFollow cameraFollow;
    private bool singleplayer = true;

    //private HamsterHealth health;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        camera = GameObject.Find("Main Camera");

        if (PhotonNetwork.IsConnected)
        {
            singleplayer = false;
        }

        //health = gameObject.GetComponent<HamsterHealth>();
    }

    public void Start()
    {
        if (!singleplayer)
        {
            if (photonView.IsMine)
            {
                cameraFollow = camera.GetComponent<CameraFollow>();
                cameraFollow.target = this.transform;
                gameManager.thisHamster = this;
            }
        }
        else
        {
            cameraFollow = camera.GetComponent<CameraFollow>();
            cameraFollow.target = this.transform;
        }
    }

    public void Update()
    {
        if (!singleplayer && Input.GetKeyDown(KeyCode.Escape))//&& PhotonView.IsMine)
        {
            //Leaving rooms is pretty buggy. LeaveRoom should call an OnLeftRoom method which we can override but for some reason it doesn't.
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Intro");
        }
        else if (singleplayer && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Intro");
        }

        gameManager.AddHamsterPosition(GetInstanceID(), transform.position);
    }

    public void RespawnAll()
    {
        photonView.RPC("Respawn", RpcTarget.All);
    }

    //Sometimes another ball spawns after reloading the scene. No idea why
    [PunRPC]
    private void Respawn()
    {
        PhotonNetwork.LoadLevel("RespawnScene");
    }

    public void DisplayDeath()
    {
        photonView.RPC("DisplayDeathForOthers", RpcTarget.Others, PhotonNetwork.LocalPlayer.NickName);
    }

    [PunRPC]
    private void DisplayDeathForOthers(string name)
    {
        Physics.IgnoreLayerCollision(16, 17, true);
        gameManager.GameOverOther(name);
    }
}
