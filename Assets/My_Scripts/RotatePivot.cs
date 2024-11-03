using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    public float rotationSpeed = 45f; // Speed of rotation

    private void Update()
    {
        // Rotate back and forth between 90 and -90 degrees on the X-axis
        float rotationAngle = Mathf.Lerp(90, -90, Mathf.PingPong(Time.time * rotationSpeed / 90f, 1));
        transform.rotation = Quaternion.Euler(rotationAngle, 0, 0);
    }
}
