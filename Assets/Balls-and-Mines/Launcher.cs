using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    private Vector3 spawnPos = new Vector3(-35.2299995f, 5.30999994f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        Debug.Log("A");
    }
}
