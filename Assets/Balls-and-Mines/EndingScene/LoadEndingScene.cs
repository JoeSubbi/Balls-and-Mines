using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndingScene : MonoBehaviour {
    private BoxCollider collider;
    public SphereCollider hamster;

    public void Start(){
        collider = GetComponent<BoxCollider>();
    }

    public void Update(){
        if (collider.bounds.Intersects(hamster.bounds)){
            SceneManager.LoadScene("EndingScene");
        }
    }
}
