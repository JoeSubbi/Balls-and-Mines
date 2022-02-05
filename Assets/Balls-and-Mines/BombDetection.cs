using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetection : MonoBehaviour
{
    private SphereCollider collider;
    public SphereCollider hamster;

    private float entryTime;
    private float detonationTime;

    private bool detonated;

    // private ParticleSystem explosionEffects;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        entryTime = 0.0F;
        detonated = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAH");
        CheckIfHamster();
        if (entryTime != 0.0F && !detonated){
            if (Time.time >= detonationTime){
                Debug.Log("EXPLODE!!!");
                var explosionEffects = GetComponentInChildren<ParticleSystem>();
                explosionEffects.Play(true);
                detonated = true;
            }
        }
    }

    void CheckIfHamster()
    {
        if (collider.bounds.Intersects(hamster.bounds)){
            if (entryTime == 0.0F){
                // Set entryTime and detonationTime
                entryTime = Time.time;
                detonationTime = Time.time + 0.2F;
                Debug.Log("Detonation time set");
            }
        }
        // Play sound
        // Set timer
        // Explode!!!
    }
}
