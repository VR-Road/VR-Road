using UnityEngine;
using TMPro;  // For TextMeshPro
using EVP;   // Import your custom namespace for VehicleController
using VR_Road.InputSystem;  // Import the VR Road Input System for handling inputs

public class GearIndicator : MonoBehaviour
{
    public DrivingControls drivingControls;  // Reference to your DrivingControls script
    public TMP_Text gearText;  // Reference to the UI Text element for displaying the gear

    private bool isDriveGear = false;  // Track whether the Drive Gear is active
    private bool isReverseGear = false;  // Track whether the Reverse Gear is active

    void OnEnable()
    {
        // Enable the DrivingControls if it's not already enabled
        if (drivingControls == null)
        {
            drivingControls = new DrivingControls();
        }

        drivingControls.Driving.Enable();
    }

    void OnDisable()
    {
        // Disable the DrivingControls when the object is disabled
        if (drivingControls != null)
        {
            drivingControls.Driving.Disable();
        }
    }

    void Update()
    {
        // Check if "Drive Gear" or "Reverse Gear" is pressed
        isDriveGear = drivingControls.Driving.DriveGear.triggered;
        isReverseGear = drivingControls.Driving.ReverseGear.triggered;

        // Set the gear indicator based on the input state
        if (isDriveGear)
        {
            gearText.text = "Gear:  D";  // Drive Gear
        }
        else if (isReverseGear)
        {
            gearText.text = "Gear:  R";  // Reverse Gear
        }
        else
        {
            gearText.text = "Gear:  P";  // Default to Park if neither gear is engaged
        }
    }
}
