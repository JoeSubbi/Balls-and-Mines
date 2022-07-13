using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour{
    public GameManager gameManager;
    public Dictionary<int, Vector3> HamsterPositions;
    private Vector3 closestHamsterPos;
    public bool fired = false;
    public float detonationForce = 100;
    private GameObject closestHamster;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update(){
        GetAllHamsterPositions();
        FindclosestHamsterPos();

        if (Vector3.Distance(closestHamsterPos, transform.position) < 60.0F)
            rotateTowards(closestHamsterPos);

        if (Vector3.Distance(closestHamsterPos, transform.position) < 30.0F){
            shoot();
        }
    }

    private void GetAllHamsterPositions()
    {
        HamsterPositions = gameManager.GetAllHamsterPositions();
    }

    private void FindclosestHamsterPos()
    {
        Vector3 closestTarget = Vector3.zero;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(KeyValuePair<int, Vector3> target in HamsterPositions)
        {
            Vector3 directionToTarget = target.Value - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestTarget = target.Value;
            }
        }

        closestHamsterPos = closestTarget;
    }

    private void rotateTowards(Vector3 to){
        Quaternion lookRotation = Quaternion.LookRotation(
                                        (to - transform.position).normalized);
        lookRotation *= Quaternion.Euler(-90, -90, 0);
        transform.rotation = lookRotation;
    }

    private void shoot(){
        if (!fired){
            var explosionEffects = GetComponentInChildren<ParticleSystem>();
            explosionEffects.Play(true);

            GameObject.Find("FX").GetComponent<AudioSource>().Play(0);
            fired = true;

            var coroutine = DelayedImpact();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator DelayedImpact(){
        var impact = GameObject.Find("Impact");
        impact.transform.position = closestHamsterPos;

        yield return new WaitForSeconds(0.2F);
        impact.GetComponent<ParticleSystem>().Play(true); 

        GameObject.Find("FX").GetComponent<AudioSource>().Play(0);

        var overlap = Physics.OverlapSphere(impact.transform.position, 10);
        foreach (var obj in overlap)
            if (obj.GetComponent<Controls>() != null)
            {
                obj.GetComponent<Rigidbody>().AddExplosionForce(detonationForce, impact.transform.position + Vector3.forward, 20);
                obj.GetComponent<HamsterHealth>().decrementHealth();
            }
    }
}