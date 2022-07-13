using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
