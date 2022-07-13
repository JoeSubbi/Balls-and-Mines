using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndingScene : MonoBehaviour {
    private BoxCollider collider;

    public void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadScene("EndingScene");
    }
}
