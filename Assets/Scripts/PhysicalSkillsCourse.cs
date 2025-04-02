using UnityEngine;
using TMPro;  // For TextMeshPro
using EVP;   // Import your custom namespace for VehicleController
using VR_Road.InputSystem;

public class PhysicalSkillsCourse : MonoBehaviour
{
    public VehicleController vehicleController;  // Reference to the VehicleController
    public TMP_Text feedbackText;  // UI Text for feedback
    public float targetSpeed1 = 15f;  // Target speed 1 (15 mph)
    public float targetSpeed2 = 40f;  // Target speed 2 (40 mph)
    public float targetSpeed3 = 55f;  // Target speed 3 (55 mph)
    public float targetSpeed4 = 15f;  // Target reverse speed 4 (15 mph)

    public float buffer1 = 3f;  // Speed buffer for target speed 1
    public float buffer2 = 5f;  // Speed buffer for target speed 2
    public float buffer3 = 8f;  // Speed buffer for target speed 3
    public float buffer4 = 3f;  // Speed buffer for target speed 4 (reverse speed)

    public Transform teleportLocation; // Reference to teleport location
    private int currentSpeedTest = 0;  // Keep track of which speed test we are on

    private void Start()
    {
        feedbackText.text = "Physical Skills Course Started: Go to 15 mph";
    }

    private void Update()
    {
        // Get the current speed using the Rigidbody.velocity.magnitude approach
        float currentSpeed = vehicleController.GetComponent<Rigidbody>().velocity.magnitude * 2.23694f;  // Convert m/s to mph

        // Speed test progression
        if (currentSpeedTest == 0 && IsSpeedInRange(currentSpeed, targetSpeed1, buffer1))
        {
            feedbackText.text = "Now go to 40 mph!";
            currentSpeedTest = 1;  // Move to the next speed test
        }
        else if (currentSpeedTest == 1 && IsSpeedInRange(currentSpeed, targetSpeed2, buffer2))
        {
            feedbackText.text = "Now go to 55 mph!";
            currentSpeedTest = 2;  // Move to the next speed test
        }
        else if (currentSpeedTest == 2 && IsSpeedInRange(currentSpeed, targetSpeed3, buffer3))
        {
            feedbackText.text = "Now slow down to 0 mph.";
            currentSpeedTest = 3;  // Move to the next test to slow down
        }
        else if (currentSpeedTest == 3 && IsSpeedInRange(currentSpeed, 0, 1f))  // Check if the car has slowed to 0 mph
        {
            feedbackText.text = "Now reverse at 15 mph.";
            currentSpeedTest = 4;  // Move to reverse test
        }
        else if (currentSpeedTest == 4 && IsSpeedInRange(currentSpeed, targetSpeed1, buffer1))  // Reverse at 15 mph
        {
            feedbackText.text = "Great! You've reversed at 15 mph. You've completed the course!";
            currentSpeedTest = 5;  // Course complete
        }
        else
        {
            // Just display the current target speed to reach
            if (currentSpeedTest == 0)
                feedbackText.text = "Part 1: Begin by accelerating smoothly to 15 mph!";
            else if (currentSpeedTest == 1)
                feedbackText.text = "Next, decelerate to a complete stop, then accelerate to 40 mph.";
            else if (currentSpeedTest == 2)
                feedbackText.text = "Finally, bring the vehicle to a full stop and accelerate to 55 mph.";
            else if (currentSpeedTest == 3)
                feedbackText.text = "Now slow down to 0 mph before reversing.";
            else if (currentSpeedTest == 4)
                feedbackText.text = "Now reverse at 15 mph. Remember, keep your speed steady!";
        }

        // Turning practice after the final reverse test
        if (currentSpeedTest == 5)  // If the course is complete, start turning practice
        {
            feedbackText.text = "Complete: Now Practice making gentle turns at your discretion.";
            currentSpeedTest = 6; // Change to turning test
        }

        // Check if the player is in the turning test and ready to teleport (press space bar)
        if (currentSpeedTest == 6)
        {
            feedbackText.text = "Great! You've completed turning practice. Press space to teleport.";
            if (Input.GetKeyDown(KeyCode.Space)) // Check for space bar press
            {
                TeleportToConesSection();
            }
        }
    }

    // Helper function to check if the current speed is within the target speed +/- buffer
    private bool IsSpeedInRange(float currentSpeed, float targetSpeed, float buffer)
    {
        return currentSpeed >= targetSpeed - buffer && currentSpeed <= targetSpeed + buffer;
    }

    private void TeleportToConesSection()
    {
        // Teleport after turning practice is completed
        if (teleportLocation != null && currentSpeedTest == 6)
        {
            vehicleController.transform.position = teleportLocation.position;
            vehicleController.transform.rotation = teleportLocation.rotation; // Align with new location
            feedbackText.text = "Cone Maneuvering! Maneuver through and stay under 20 mph!";
            currentSpeedTest = 7; // Prevent repeated teleporting
        }
    }
}
