using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour{
    public void StartGame(){
        SceneManager.LoadScene("DMZ");
    }
}