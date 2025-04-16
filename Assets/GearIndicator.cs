using UnityEngine;
using TMPro;
using VR_Road.InputSystem;

public class GearIndicator : MonoBehaviour
{
    public DrivingControls drivingControls;
    public TMP_Text gearText;
    
    private bool currentDriveState = false;
    private bool currentReverseState = false;

    void OnEnable()
    {
        if (drivingControls == null)
        {
            drivingControls = new DrivingControls();
        }
        drivingControls.Driving.Enable();
    }

    void OnDisable()
    {
        if (drivingControls != null)
        {
            drivingControls.Driving.Disable();
        }
    }

    void Update()
    {
        // Check for gear toggle inputs
        if (drivingControls.Driving.DriveGear.triggered)
        {
            currentDriveState = !currentDriveState;
            if (currentDriveState) currentReverseState = false;
        }
        
        if (drivingControls.Driving.ReverseGear.triggered)
        {
            currentReverseState = !currentReverseState;
            if (currentReverseState) currentDriveState = false;
        }

        // Update display based on current state
        if (currentDriveState)
        {
            gearText.text = "Gear: D";
        }
        else if (currentReverseState)
        {
            gearText.text = "Gear: R";
        }
        else
        {
            gearText.text = "Gear: P";
        }
    }
}