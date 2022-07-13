using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Respawn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.LoadLevel("DMZ_Multiplayer");
    }
}
