using UnityEngine;
using TMPro;
using EVP; // Your custom namespace for VehicleController

public class InstructionHider : MonoBehaviour
{
    public VehicleController vehicleController;  // Reference to the VehicleController
    public GameObject instructionCanvas;  // Reference to the Canvas containing the instructions
    public float speedThreshold = 5f;  // Speed threshold to hide the instructions (5 mph)

    void Update()
    {
        if (vehicleController != null && instructionCanvas != null)
        {
            // Get current speed from the VehicleController (convert to mph)
            float currentSpeed = vehicleController.GetComponent<Rigidbody>().velocity.magnitude * 2.23694f;

            // If speed exceeds the threshold, hide the instructions
            if (currentSpeed >= speedThreshold)
            {
                instructionCanvas.SetActive(false);  // Hide the instructions
            }
        }
    }
}
