using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejoinPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float RejoinMovementSpeed;
    public float JumpHeight;
    public bool IsJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal") * RejoinMovementSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * RejoinMovementSpeed * Time.deltaTime;

        rb.AddForce(-y, 0, x);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            IsJumping = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            IsJumping = false;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
        {
            rb.AddForce(0, JumpHeight * Time.deltaTime, 0, ForceMode.Impulse);
            IsJumping = false;
        }
    }
}
