using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetection : MonoBehaviour
{
    private SphereCollider collider;
    public SphereCollider hamster;

    private float entryTime;
    private float detonationTime;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        entryTime = 0.0F;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAH");
        CheckIfHamster();
    }

    void CheckIfHamster()
    {
        if (collider.bounds.Intersects(hamster.bounds)){
            if (entryTime != 0.0F){
                if (Time.time >= detonationTime){
                    // EXPLODE
                    Debug.Log("EXPLODE!!!");
                }
            } else {
                // Set entryTime and detonationTime
                entryTime = Time.time;
                detonationTime = Time.time + 2;
                Debug.Log("Detonation time set");
            }
        }
        // Play sound
        // Set timer
        // Explode!!!
    }
}
