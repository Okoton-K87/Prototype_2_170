using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;

    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Rigidbody PlayerBody;

    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float ExtraGravity = 20f; // Additional gravity for weightier feel

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerBody.mass = 2f;  // Increase mass for weightier collisions
        PlayerBody.drag = 0.5f; 
    }

    private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, JumpForce, 0f);
        }

        if (!IsGrounded())
        {
            PlayerBody.AddForce(Vector3.down * ExtraGravity, ForceMode.Acceleration);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask);
    }
}
