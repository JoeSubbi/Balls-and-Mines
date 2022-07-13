using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject gameOver;
    private Dictionary<int, Vector3> hamsterPositions = new Dictionary<int, Vector3>();
    public Hamster thisHamster;
    public TextMeshProUGUI deathMessage;

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void GameOverSelf(string name)
    {
        thisHamster.DisplayDeath();
        gameOver.SetActive(true);
        deathMessage.text = name + " DIED... NOOOOO!";
    }

    public void GameOverOther(string name)
    {
        gameOver.SetActive(true);
        deathMessage.text = name + " DIED... NOOOOO!";
    }

    public void AddHamsterPosition(int id, Vector3 newPosition)
    {
        hamsterPositions[id] = newPosition;
    }

    public Dictionary<int, Vector3> GetAllHamsterPositions()
    {
        return hamsterPositions;
    }

    public void RespawnAll()
    {
        thisHamster.RespawnAll();
    }
}
