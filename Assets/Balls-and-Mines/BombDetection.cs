using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetection : MonoBehaviour
{
    private SphereCollider collider;
    public SphereCollider hamster;

    private float detonationTime;
    private bool detonated;
    private bool armed;
    public float detonationForce = 300;

    private GameObject hamsterHit;

    // private ParticleSystem explosionEffects;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        detonated = false;
        armed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (armed == true && detonated == false){
            if (Time.time >= detonationTime){
                var explosionEffects = GetComponentInChildren<ParticleSystem>();
                explosionEffects.Play(true);

                GameObject.Find("FX").GetComponent<AudioSource>().Play(0);

                detonated = true;
                var overlap = Physics.OverlapSphere(transform.position, 10);
                foreach (var obj in overlap)
                    if (obj.GetComponent<Controls>() != null)
                        obj.GetComponent<Rigidbody>().AddExplosionForce(detonationForce, transform.position + Vector3.down, 10);
                        hamsterHit.GetComponent<HamsterHealth>().decrementHealth();
                        StartCoroutine(DestroySelf());
            }
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider col)
    {
        armed = true;
        detonationTime = Time.time + 0.2f;
        hamsterHit = col.gameObject;
    }
}
