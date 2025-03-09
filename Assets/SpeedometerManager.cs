using UnityEngine;
using TMPro; // Importing TextMeshPro namespace
using UnityStandardAssets.Vehicles.Car; 

public class SpeedometerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText; // Drag your TextMeshPro Text here
    [SerializeField] private CarController carController; // Drag your CarController object here

    void Update()
    {
        if (carController != null && speedText != null)
        {
            // Update the speed value displayed on the screen
            float currentSpeed = carController.CurrentSpeed;

            // Display speed in MPH or KPH depending on what you prefer
            speedText.text = currentSpeed.ToString("0") + " MPH"; // You can change "MPH" to "KPH" if you like
        }
    }
}
