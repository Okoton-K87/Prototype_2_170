using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public Vector3 initialPosition = new Vector3(10f, 0f, 0f); // Set the initial position in the Inspector
    public float leftMoveSpeed = 2f; // Set the speed for moving left forever
    private bool shouldMoveLeft = false; // Flag to control movement

    private void Start()
    {
        // Instantly move Dog to the initial position
        transform.position = initialPosition;
    }

    private void Update()
    {
        // Only move left if shouldMoveLeft is true
        if (shouldMoveLeft)
        {
            transform.position += Vector3.left * leftMoveSpeed * Time.deltaTime;
        }
    }

    // Method to start the leftward movement
    public void StartMovingDog()
    {
        shouldMoveLeft = true;
    }
}
