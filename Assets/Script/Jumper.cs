using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public GameObject NativePlayer;
    public GameObject RejoinPlayer;
    public Vector3 JumpHeight;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NativePlayer.GetComponent<Rigidbody>().AddForce(JumpHeight);
            RejoinPlayer.GetComponent<Rigidbody>().AddForce(JumpHeight);
        }
    }
}
