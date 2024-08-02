using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100f;
    private bool canJump = true;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && canJump)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on the screen
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        // Add force to make the player jump
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Prevent multiple jumps until the player lands
        canJump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Allow jumping again when the player lands
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
