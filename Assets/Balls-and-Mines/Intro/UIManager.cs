using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("DMZ");
    }

    public void StartMultiplayer()
    {
        SceneManager.LoadScene("MultiplayerMenu");
    }
}