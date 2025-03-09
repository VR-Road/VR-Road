using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class SpeedTest : MonoBehaviour
{
    public CarController carController;  // Reference to the CarController
    public Text feedbackText;  // UI Text for feedback
    public float targetSpeed1 = 15f;  // Target speed 1 (15 mph)
    public float targetSpeed2 = 40f;  // Target speed 2 (40 mph)
    public float targetSpeed3 = 55f;  // Target speed 3 (55 mph)

    public float buffer1 = 3f;  // Speed buffer for target speed 1
    public float buffer2 = 5f;  // Speed buffer for target speed 2
    public float buffer3 = 8f;  // Speed buffer for target speed 3

    private int currentSpeedTest = 0;  // Keep track of which speed test we are on

    private void Start()
    {
        feedbackText.text = "Speed Test Started: Go to 15 mph";
    }

    private void Update()
    {
        float currentSpeed = carController.CurrentSpeed;  // Get current speed from CarController

        // Check if we are at the correct speed for each target
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
            feedbackText.text = "You've completed part 1!";
            currentSpeedTest = 3;  // All tests completed
        }
        else
        {
            // Just display the current target speed to reach
            if (currentSpeedTest == 0)
                feedbackText.text = "Part 1: Begin by accelerating smoothly to 15 mph to start the course.";
            else if (currentSpeedTest == 1)
                feedbackText.text = "Next, decelerate to a complete stop, then accelerate to 40 mph.";
            else if (currentSpeedTest == 2)
                feedbackText.text = "Finally, bring the vehicle to a full stop and accelerate to 55 mph.";
            }
    }

    // Helper function to check if the current speed is within the target speed +/- buffer
    private bool IsSpeedInRange(float currentSpeed, float targetSpeed, float buffer)
    {
        return currentSpeed >= targetSpeed - buffer && currentSpeed <= targetSpeed + buffer;
    }
}
