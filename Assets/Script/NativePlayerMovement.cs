using UnityEngine;

public class NativePlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float NativeMovementSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal") * NativeMovementSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * NativeMovementSpeed * Time.deltaTime;

        rb.AddForce(-y, 0, x);
    }
}
