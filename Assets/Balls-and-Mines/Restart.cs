using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Restart : MonoBehaviourPunCallbacks
{
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.UnloadScene(scene.name);
        SceneManager.LoadScene(scene.name);
    }
}
