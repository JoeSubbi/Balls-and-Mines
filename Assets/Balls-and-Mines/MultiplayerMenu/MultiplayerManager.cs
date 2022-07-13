using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviourPunCallbacks{
    public TMP_InputField roomName;
    public TMP_InputField username;
    public TextMeshProUGUI log;
    public Button startGameButton;
    public Button createRoomButton;
    public ScrollRect logScroll;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Intro");
        }
    }

    public void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected && roomName.text.Length > 0 && username.text.Length > 0)
        {
            PhotonNetwork.LocalPlayer.NickName = username.text;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        log.text += " " + newPlayer.NickName + " joined.\n";
        logScroll.normalizedPosition = new Vector2(0, 0);
    }

    public override void OnPlayerLeftRoom(Player leftPlayer)
    {
        log.text += " " + leftPlayer.NickName + " left.\n";
        logScroll.normalizedPosition = new Vector2(0, 0);
    }

    public override void OnCreatedRoom()
    {
        log.text = " Room " + roomName.text + " created.\n";
        roomName.gameObject.SetActive(false);
        username.gameObject.SetActive(false);
        createRoomButton.gameObject.SetActive(false);

        startGameButton.gameObject.SetActive(true);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create");
    }

    public override void OnJoinedRoom()
    {
        log.text += " " + username.text + " joined.\n";
        logScroll.normalizedPosition = new Vector2(0, 0);

        roomName.gameObject.SetActive(false);
        username.gameObject.SetActive(false);
        createRoomButton.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("DMZ_Multiplayer");
    }
    
}