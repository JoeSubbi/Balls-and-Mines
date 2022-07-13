using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Controls : MonoBehaviourPunCallbacks
{
    private Vector3 force;
    public Rigidbody target;
    public float boost = 1.1F;
    public float smoothing = 0.2f;

    private Vector3 jump = Vector3.up;
    public float jumpForce = 1.4f;
    private bool isGrounded;

    public Camera cam;

    private bool singleplayer = true;

    public void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            singleplayer = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (singleplayer)
        {
            if (HamsterHealth.life)
            {
                if (Input.GetKey("w"))
                    force.x = 1;
                if (Input.GetKey("s"))
                    force.x = -1;

                if (Input.GetKey("a"))
                    force.z = 2;
                if (Input.GetKey("d"))
                    force.z = -2;

                if (Input.GetKey("space") && isGrounded)
                {
                    target.AddForce(jump * jumpForce, ForceMode.Impulse);
                    isGrounded = false;
                }

                force = Vector3.Lerp(force, new Vector3(0, 0, 0), smoothing);

                target.AddForce(force * boost);
            }
        }
        else
        {
            if (HamsterHealth.life && photonView.IsMine)
            {
                if (Input.GetKey("w"))
                    force.x = 1;
                if (Input.GetKey("s"))
                    force.x = -1;

                if (Input.GetKey("a"))
                    force.z = 2;
                if (Input.GetKey("d"))
                    force.z = -2;

                if (Input.GetKey("space") && isGrounded)
                {
                    target.AddForce(jump * jumpForce, ForceMode.Impulse);
                    isGrounded = false;
                }

                force = Vector3.Lerp(force, new Vector3(0, 0, 0), smoothing);

                target.AddForce(force * boost);
            }
        }
        
    }

    void OnCollisionEnter(){
        isGrounded = true;

        GetComponent<AudioSource>().Play(0);
    }
}
