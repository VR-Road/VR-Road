using UnityEngine;
using UnityEngine.InputSystem;
using VR_Road.InputSystem;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    private CarController carController; // Reference to the car controller
    private DrivingControls drivingControls; // Reference to the Input Action Asset

    private float accelerationInput = 0f; // Accelerator input (default to 0)
    private float brakeInput = 0f; // Brake input (default to 0)
    private float steeringInput = 0f; // Steering input from the stick

    [Header("Car Tuning")]
    [SerializeField, Range(0.1f, 50f)] private float accelerationForce = 10f; // Acceleration force (rear-wheel bias)
    [SerializeField, Range(0.1f, 50000f)] private float brakeForce = 20000f; // Increased brake force
    [SerializeField, Range(0.1f, 5f)] private float steeringStrength = 1f; // Steering responsiveness
    [SerializeField, Range(0f, 1f)] private float rearWheelBias = 0.7f; // Rear-wheel drive bias (0 = front, 1 = rear)

    private void Awake()
    {
        // Get the car controller
        carController = GetComponent<CarController>();

        // Initialize the Input System
        drivingControls = new DrivingControls();

        // Subscribe to input events
        drivingControls.Driving.AcceleratorPedal.performed += ctx => accelerationInput = ctx.ReadValue<float>();
        drivingControls.Driving.AcceleratorPedal.canceled += _ => accelerationInput = 0f; // Default to 0 (no input)

        drivingControls.Driving.BrakePedal.performed += ctx => brakeInput = ctx.ReadValue<float>();
        drivingControls.Driving.BrakePedal.canceled += _ => brakeInput = 0f; // Default to 0 (no input)

        drivingControls.Driving.Steering.performed += ctx => steeringInput = ctx.ReadValue<float>();
        drivingControls.Driving.Steering.canceled += _ => steeringInput = 0f; // Default to 0 (centered)
    }

    private void OnEnable()
    {
        // Enable the Input System
        drivingControls.Enable();
    }

    private void OnDisable()
    {
        // Disable the Input System
        drivingControls.Disable();
    }

    private void FixedUpdate()
    {
        // Calculate the final steering value
        float finalSteering = CalculateSteering();

        // Map accelerator and brake inputs to a progressive range (0 to 1)
        float mappedAccelerator = MapInput(accelerationInput, -1f, 1f, 0f, 1f);
        float mappedBrake = MapInput(brakeInput, -1f, 1f, 0f, 1f);

        // Ensure the car remains stationary when no input is applied
        if (Mathf.Approximately(accelerationInput, 0f))
        {
            mappedAccelerator = 0f; // Default to 0 (no input)
        }

        if (Mathf.Approximately(brakeInput, 0f))
        {
            mappedBrake = 0f; // Default to 0 (no input)
        }

        // Apply rear-wheel drive bias to acceleration
        float rearAcceleration = mappedAccelerator * accelerationForce * rearWheelBias;
        float frontAcceleration = mappedAccelerator * accelerationForce * (1f - rearWheelBias);

        // Apply brake force
        float totalBrakeForce = mappedBrake * brakeForce;

        // Pass the inputs to the car controller
        carController.Move(finalSteering, frontAcceleration + rearAcceleration, totalBrakeForce, 0f); // Set handbrake to 0 (since it doesn't exist)

        // Debug logs for testing
        Debug.Log($"Steering: {finalSteering}, Accelerator: {mappedAccelerator}, Brake: {mappedBrake}");
    }

    private float CalculateSteering()
    {
        // If the steering input reaches -1 or 1, reset it to 0
        if (Mathf.Approximately(steeringInput, -1f) || Mathf.Approximately(steeringInput, 1f))
        {
            steeringInput = 0f; // Reset to center
        }

        // Clamp the steering input to ensure it never reaches -1 or 1
        float clampedSteering = Mathf.Clamp(steeringInput, -0.99f, 0.99f);

        // Invert the steering input to fix the inverted wheel issue
        float invertedSteering = -clampedSteering;

        // Apply steering strength
        float finalSteering = invertedSteering * steeringStrength * 0.5f; // Reduce steering sensitivity by 50%

        // Reduce steering sensitivity at high speeds (optional)
        float speedFactor = Mathf.Clamp01(carController.CurrentSpeed / 50f); // Adjust 50f to your car's max speed
        finalSteering *= (1f - speedFactor * 0.5f); // Reduce steering by up to 50% at high speeds

        return finalSteering;
    }

    // Helper function to map input values to a progressive range
    private float MapInput(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return Mathf.Lerp(outputMin, outputMax, Mathf.InverseLerp(inputMin, inputMax, value));
    }
}