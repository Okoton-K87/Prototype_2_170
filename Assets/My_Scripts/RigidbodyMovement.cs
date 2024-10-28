using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    // Input variable for player movement
    private Vector3 PlayerMovementInput;

    // Serialized fields for setting in the Unity Inspector
    [SerializeField] private LayerMask FloorMask; // LayerMask to detect the floor for grounding
    [SerializeField] private Transform FeetTransform; // Player's feet position for ground detection
    [SerializeField] private Rigidbody PlayerBody; // Rigidbody for physics-based movement

    [Space]
    [SerializeField] private float Speed; // Movement speed
    [SerializeField] private float JumpForce; // Force applied for jumping

    private void Start()
    {
        // Lock the cursor and hide it (optional for this 2D-like setup)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Capture player input for horizontal movement (A and D keys)
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        // Call the method responsible for moving the player
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Translate movement input into world space direction (left or right) relative to the player
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;

        // Apply movement while preserving the player's current vertical velocity (for jumping)
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, 0f);

        // Optional jump if space is pressed and the player is grounded (using Physics.CheckSphere)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if the player's feet are grounded (using a small sphere at the feet)
            if (Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask))
            {
                // Apply an upward force to make the player jump
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }
}
