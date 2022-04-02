using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private int jumpCount = 1;
    private int numJumps = 2;
    private float jumpForce = 175;
    private float distanceGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distanceGround = GetComponent<Collider> ().bounds.extents.y;
    }

    // When space is pressed a force will be applied to the player making it
    // jump, only can jump numJumps times
    void OnJump()
    {
        if (jumpCount < numJumps)
        {
            Vector3 jump = new Vector3(0.0f, 1f, 0.0f);
            rb.AddForce(jump * jumpForce);
            jumpCount = jumpCount + 1;
        }
    }

    // On every phisics update it will check to see if the player is touching
    // the ground. If they are then the jump counter will be set to zero.
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distanceGround))
        {
            jumpCount = 1;
        }
    }
}
