using UnityEngine;
using VR_Road.InputSystem;

namespace EVP
{
    public class VehicleStandardInput : MonoBehaviour
    {
        public VehicleController target;

        public bool continuousForwardAndReverse = true;

        public enum ThrottleAndBrakeInput { SingleAxis, SeparateAxes };
        public ThrottleAndBrakeInput throttleAndBrakeInput = ThrottleAndBrakeInput.SingleAxis;
        public bool handbrakeOverridesThrottle = false;

        [Space(5)]
        public string steerAxis = "Horizontal";
        public string throttleAndBrakeAxis = "Vertical";
        public string throttleAxis = "Fire2";
        public string brakeAxis = "Fire3";
        public string handbrakeAxis = "Jump";
        public KeyCode resetVehicleKey = KeyCode.Return;

        private DrivingControls m_DrivingControls;
        private bool m_doReset = false;

        void OnEnable()
        {
            // Cache vehicle
            if (target == null)
                target = GetComponent<VehicleController>();

            // Initialize the new input system
            m_DrivingControls = new DrivingControls();
            m_DrivingControls.Driving.Enable();
        }

        void OnDisable()
        {
            if (target != null)
            {
                target.steerInput = 0.0f;
                target.throttleInput = 0.0f;
                target.brakeInput = 0.0f;
                target.handbrakeInput = 0.0f;
            }

            // Disable the new input system
            m_DrivingControls?.Driving.Disable();
        }

        void Update()
        {
            if (target == null) return;

            if (Input.GetKeyDown(resetVehicleKey)) m_doReset = true;
        }

       void FixedUpdate()
{
    if (target == null) return;

    // Read the user input from the new input system
    float steerInput = m_DrivingControls.Driving.Steering.ReadValue<float>();
    float brakeInput = m_DrivingControls.Driving.BrakePedal.ReadValue<float>();
    float throttleInput = m_DrivingControls.Driving.AcceleratorPedal.ReadValue<float>();

    // Debugging: Print raw inputs
    Debug.Log($"Raw Steer Input: {steerInput}, Raw Throttle Input: {throttleInput}, Raw Brake Input: {brakeInput}");

    // Handle steering input
    if (steerInput == -1.0f)
    {
        steerInput = 0.0f; // Resting state, no steering
    }

    // Invert the steering direction
    steerInput *= -1;

    // Handle brake and throttle inputs
    if (brakeInput == -1.0f)
    {
        brakeInput = 0.0f; // Resting state, no braking
    }
    else
    {
        brakeInput = Mathf.Clamp(brakeInput, -0.99f, 0.99f); // Clamp to avoid exact -1 or 1
    }

    if (throttleInput == -1.0f)
    {
        throttleInput = 0.0f; // Resting state, no throttle
    }
    else
    {
        throttleInput = Mathf.Clamp(throttleInput, -0.99f, 0.99f); // Clamp to avoid exact -1 or 1
    }

    // Debugging: Print final inputs
    Debug.Log($"Final Steer Input: {steerInput}, Final Throttle Input: {throttleInput}, Final Brake Input: {brakeInput}");

    // Apply input to vehicle
    target.steerInput = steerInput;
    target.throttleInput = throttleInput;
    target.brakeInput = brakeInput;

    // Do a vehicle reset
    if (m_doReset)
    {
        target.ResetVehicle();
        m_doReset = false;
    }
}
    }
}