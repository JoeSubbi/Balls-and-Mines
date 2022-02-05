using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private Vector3 force;
    public Rigidbody target;
    public float boost = 1.1F;
    public float smoothing = 0.2f;

    private Vector3 jump = Vector3.up;
    public float jumpForce = 1.4f;
    private bool isGrounded;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
            force.x ++;
        if (Input.GetKey("s"))
            force.x --;

        if (Input.GetKey("a"))
            force.z++;
        if (Input.GetKey("d"))
            force.z--;
        
        if (Input.GetKey("space") && isGrounded){
            target.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        force = Vector3.Lerp(force, new Vector3(0,0,0), smoothing);

        target.AddForce(force * boost);

    }

    void OnCollisionStay(){
        isGrounded = true;
    }
}
