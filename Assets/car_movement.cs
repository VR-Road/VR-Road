using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_movement : MonoBehaviour
{
    public float moveSpeed = 30f; // Speed of the car
    public float turnSpeed = 50f; // Turning speed of the car
    public Transform Steering_wheel; // Reference to the steering wheel object

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the steering wheel stays in its initial position and orientation
        if (Steering_wheel != null)
        {
            // Keep the wheel fixed with an initial tilt of -45 degrees along the Z-axis
            Steering_wheel.localRotation = Quaternion.Euler(0f, 0f, -45f); // Tilt the wheel
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for forward/backward movement
        float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down

        // Get input for turning
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // Move the car forward or backward
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Turn the car (rotate around Y-axis)
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);

        // Do nothing with the steering wheel — it stays static
        // No changes to the steering wheel rotation, just keeping it in place
    }
}