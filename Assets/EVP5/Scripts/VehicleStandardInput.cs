
// using UnityEngine;
// using VR_Road.InputSystem;
// using TMPro;

// namespace EVP
// {
//     public class VehicleStandardInput : MonoBehaviour
//     {
//         [Header("Vehicle Controller")]
//         public VehicleController target;

//         [Header("Gear Settings")]
//         public bool driveGear = false;
//         public bool reverseGear = false;

//         [Header("Gear Display")]
//         public TMP_Text gearDisplayText;

//         [Header("Input Settings")]
//         public bool continuousForwardAndReverse = true;

//         public enum ThrottleAndBrakeInput { SingleAxis, SeparateAxes };
//         public ThrottleAndBrakeInput throttleAndBrakeInput = ThrottleAndBrakeInput.SingleAxis;
//         public bool handbrakeOverridesThrottle = false;

//         [Space(5)]
//         public string steerAxis = "Horizontal";
//         public string throttleAndBrakeAxis = "Vertical";
//         public string throttleAxis = "Fire2";
//         public string brakeAxis = "Fire3";
//         public string handbrakeAxis = "Jump";
//         public KeyCode resetVehicleKey = KeyCode.Return;

//         private DrivingControls m_DrivingControls;
//         private bool m_doReset = false;

//         void OnEnable()
//         {
//             if (target == null)
//                 target = GetComponent<VehicleController>();

//             m_DrivingControls = new DrivingControls();
//             m_DrivingControls.Driving.Enable();

//             m_DrivingControls.Driving.DriveGear.performed += ctx => ToggleDriveGear();
//             m_DrivingControls.Driving.ReverseGear.performed += ctx => ToggleReverseGear();
//         }

//         void OnDisable()
//         {
//             if (target != null)
//             {
//                 target.steerInput = 0.0f;
//                 target.throttleInput = 0.0f;
//                 target.brakeInput = 0.0f;
//                 target.handbrakeInput = 0.0f;
//             }

//             m_DrivingControls?.Driving.Disable();

//             m_DrivingControls.Driving.DriveGear.performed -= ctx => ToggleDriveGear();
//             m_DrivingControls.Driving.ReverseGear.performed -= ctx => ToggleReverseGear();
//         }

//         void Update()
//         {
//             if (target == null) return;

//             if (Input.GetKeyDown(resetVehicleKey)) m_doReset = true;

//             UpdateGearDisplay();
//         }

//       void FixedUpdate()
// {
//     if (target == null) return;

//     // Original input reading (keeping your -1 inversion)
//     float rawSteerInput = m_DrivingControls.Driving.Steering.ReadValue<float>();
//     rawSteerInput *= -1;

//     // Original resting state check
//     if (rawSteerInput >= 0.99f || rawSteerInput <= -0.99f)
//     {
//         rawSteerInput = 0.0f;
//     }

//     // FIXED VERSION - PROPER DIRECTION HANDLING
//     // Convert input range while preserving direction
//     float curvedSteer;
//     if (rawSteerInput > 0f)
//     {
//         // Right turn (input 0→+1 becomes output +1→0)
//         curvedSteer = 1f - rawSteerInput;
//     }
//     else if (rawSteerInput < 0f)
//     {
//         // Left turn (input -1→0 becomes output 0→-1)
//         curvedSteer = -1f - rawSteerInput;
//     }
//     else
//     {
//         // Centered
//         curvedSteer = 0f;
//     }

//     // Add realistic steering effects based on speed
//     float speed = target.speed; // Use the available speed property
//     float speedFactor = Mathf.InverseLerp(0.1f, 12.0f, Mathf.Abs(speed));
    
//     // Reduce steering sensitivity at higher speeds
//     float steerMagnitude = Mathf.Abs(curvedSteer);
//     float curvedMagnitude = steerMagnitude * (1.0f - speedFactor * 0.2f); // Reduce steering by up to 70% at high speed
//     curvedSteer = Mathf.Sign(curvedSteer) * curvedMagnitude;

//     // Add counter-steering effect when drifting (using speedAngle as an approximation)
//     float driftFactor = Mathf.Clamp01((Mathf.Abs(target.speedAngle) - 10f) / 20f); // Adjust values to match your vehicle
//     curvedSteer *= (1f + driftFactor * Mathf.Sign(target.speedAngle) * Mathf.Sign(curvedSteer));

//     // Original smoothing with speed-based adjustment
//     float smoothFactor = Mathf.Lerp(5f, 10f, speedFactor); // Slower smoothing at low speeds
//     target.steerInput = curvedSteer;

//     // MODIFIED THROTTLE HANDLING - Convert -1→1 to 0→1
//     float rawThrottle = m_DrivingControls.Driving.AcceleratorPedal.ReadValue<float>();
//     float throttleInput = (rawThrottle + 1f) * 0.5f; // Simple remap [-1,1] → [0,1]
    
//     // Original brake handling (unchanged)
//     float brakeInput = m_DrivingControls.Driving.BrakePedal.ReadValue<float>();
//     if (brakeInput == -1.0f) brakeInput = 0.0f;
//     else brakeInput = Mathf.Clamp(brakeInput, -0.99f, 0.99f);

//     // Original gear logic (unchanged)
//     if (driveGear)
//     {
//         target.throttleInput = throttleInput; // Now 0→1 range only
//         target.brakeInput = brakeInput;
//     }
//     else if (reverseGear)
//     {
//         target.throttleInput = -throttleInput; // Now -1→0 range only
//         target.brakeInput = brakeInput;
//     }
//     else
//     {
//         target.throttleInput = 0.0f;
//         target.brakeInput = brakeInput;
//     }

//     if (m_doReset)
//     {
//         target.ResetVehicle();
//         m_doReset = false;
//     }
// }

//         void ToggleDriveGear()
//         {
//             driveGear = !driveGear;
//             if (driveGear) reverseGear = false;
//         }

//         void ToggleReverseGear()
//         {
//             reverseGear = !reverseGear;
//             if (reverseGear) driveGear = false;
//         }

//         void UpdateGearDisplay()
//         {
//             if (gearDisplayText != null)
//             {
//                 if (driveGear)
//                 {
//                     gearDisplayText.text = "D";
//                 }
//                 else if (reverseGear)
//                 {
//                     gearDisplayText.text = "R";
//                 }
//                 else
//                 {
//                     gearDisplayText.text = "P";
//                 }
//             }
//         }
//     }
// }



using UnityEngine;
using VR_Road.InputSystem;
using TMPro;

namespace EVP
{
    public class VehicleStandardInput : MonoBehaviour
    {
        [Header("Vehicle Controller")]
        public VehicleController target;

        [Header("Gear Settings")]
        public bool driveGear = false;
        public bool reverseGear = false;

        [Header("Gear Display")]
        public TMP_Text gearDisplayText;

        [Header("Input Settings")]
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

        
        [Header("Speed Limit")]
        [Tooltip("Maximum speed in MPH")]
        public float maxSpeedMPH = 30f;

        private DrivingControls m_DrivingControls;
        private bool m_doReset = false;

        void OnEnable()
        {
            if (target == null)
                target = GetComponent<VehicleController>();

            m_DrivingControls = new DrivingControls();
            m_DrivingControls.Driving.Enable();

            m_DrivingControls.Driving.DriveGear.performed += ctx => ToggleDriveGear();
            m_DrivingControls.Driving.ReverseGear.performed += ctx => ToggleReverseGear();
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

            m_DrivingControls?.Driving.Disable();

            m_DrivingControls.Driving.DriveGear.performed -= ctx => ToggleDriveGear();
            m_DrivingControls.Driving.ReverseGear.performed -= ctx => ToggleReverseGear();
        }

        void Update()
        {
            if (target == null) return;

            if (Input.GetKeyDown(resetVehicleKey)) m_doReset = true;

            UpdateGearDisplay();
        }

        void FixedUpdate()
        {
            if (target == null) return;

            // Original input reading (keeping your -1 inversion)
            float rawSteerInput = m_DrivingControls.Driving.Steering.ReadValue<float>();
            rawSteerInput *= -1;
            

            // Original resting state check
            if (rawSteerInput > 0.99f || rawSteerInput < -0.99f)
            {
                rawSteerInput = 0.0f;
            }

            // Convert input range while preserving direction
            float curvedSteer;
            if (rawSteerInput > 0f)
            {
                // Right turn (input 0→+1 becomes output +1→0)
                curvedSteer = 1f - rawSteerInput;
            }
            else if (rawSteerInput < 0f)
            {
                // Left turn (input -1→0 becomes output 0→-1)
                curvedSteer = -1f - rawSteerInput;
            }
            else
            {
                // Centered
                curvedSteer = 0f;
            }

            target.steerInput = curvedSteer;

            // MODIFIED THROTTLE HANDLING - Convert -1→1 to 0→1
            float rawThrottle = m_DrivingControls.Driving.AcceleratorPedal.ReadValue<float>();
            float throttleInput = (rawThrottle + 1f) * 0.5f; // Simple remap [-1,1] → [0,1]
            
            // Original brake handling (unchanged)
            float brakeInput = m_DrivingControls.Driving.BrakePedal.ReadValue<float>();
            if (brakeInput == -1.0f) brakeInput = 0.0f;
            else brakeInput = Mathf.Clamp(brakeInput, -0.99f, 0.99f);

            float maxSpeedMPS = maxSpeedMPH * 0.44704f;



            // Original gear logic (unchanged)
            if (driveGear)
            {
                if (target.speed >= maxSpeedMPS)
                {
                    target.throttleInput = 0f; // Hard stop acceleration
                }
                else
                {
                    target.throttleInput = throttleInput;
                }

                target.brakeInput = brakeInput;
            }
            else if (reverseGear)
            {
                target.throttleInput = -throttleInput; // Now -1→0 range only
                target.brakeInput = brakeInput;
            }
            else
            {
                target.throttleInput = 0.0f;
                target.brakeInput = brakeInput;
            }

            if (m_doReset)
            {
                target.ResetVehicle();
                m_doReset = false;
            }
        }

        void ToggleDriveGear()
        {
            driveGear = !driveGear;
            if (driveGear) reverseGear = false;
        }

        void ToggleReverseGear()
        {
            reverseGear = !reverseGear;
            if (reverseGear) driveGear = false;
        }

        void UpdateGearDisplay()
        {
            if (gearDisplayText != null)
            {
                if (driveGear)
                {
                    gearDisplayText.text = "D";
                }
                else if (reverseGear)
                {
                    gearDisplayText.text = "R";
                }
                else
                {
                    gearDisplayText.text = "P";
                }
            }
        }
    }
}



