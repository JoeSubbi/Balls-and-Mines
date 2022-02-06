using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour{
    public Vector3 HamsterPosition;
    public bool fired = false;
    public float detonationForce = 100;

    public void Start(){
        HamsterPosition = GameObject.Find("Ball").transform.position;
    }

    public void Update(){
        HamsterPosition = GameObject.Find("Ball").transform.position;
        rotateTowards(HamsterPosition);

        if (Vector3.Distance(HamsterPosition, transform.position) < 30.0F){
            shoot();
        }
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
            fired = true;

            var coroutine = DelayedImpact();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator DelayedImpact(){
            var impact = GameObject.Find("Impact");
            impact.transform.position = HamsterPosition;

            yield return new WaitForSeconds(0.2F);
            impact.GetComponent<ParticleSystem>().Play(true);
            
            var overlap = Physics.OverlapSphere(impact.transform.position, 10);
                foreach (var obj in overlap)
                    if (obj.GetComponent<Controls>() != null)
                        // for some reason this force isn't being applied right now
                        obj.GetComponent<Rigidbody>().AddExplosionForce(detonationForce, transform.position + Vector3.forward, 20);
                        GameObject.Find("Ball").GetComponent<HamsterHealth>().decrementHealth();
    }
}