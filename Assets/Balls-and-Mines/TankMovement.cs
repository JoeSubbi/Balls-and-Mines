using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour{
    public Vector3 HamsterPosition;

    public void Start(){
        HamsterPosition = GameObject.Find("Ball").transform.position;
    }

    public void Update(){
        HamsterPosition = GameObject.Find("Ball").transform.position;
        rotateTowards(HamsterPosition);
    }

    private void rotateTowards(Vector3 to){
        Quaternion lookRotation = Quaternion.LookRotation(
                                        (to - transform.position).normalized);
        lookRotation *= Quaternion.Euler(-90, -90, 0);
        transform.rotation = lookRotation;
    }
}