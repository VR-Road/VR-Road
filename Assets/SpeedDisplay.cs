using UnityEngine;
using UnityEngine.UI; // Required for Text UI elements
using UnityStandardAssets.Vehicles.Car; // Required to access the CarController class
using TMPro; 

public class SpeedDisplay : MonoBehaviour
{
    public CarController carController;  // Reference to the CarController script
    public TMP_Text speedText;               // Reference to the UI Text element for displaying speed

    void Start()
    {
        // Ensure carController is assigned, otherwise try to find it on the same GameObject
        if (carController == null)
        {
            carController = GetComponent<CarController>();
        }

        // Log an error if carController is still null
        if (carController == null)
        {
            Debug.LogError("CarController component is not assigned and could not be found on the GameObject.");
        }

        // Ensure speedText is assigned
        if (speedText == null)
        {
            Debug.LogError("SpeedText UI Text component is not assigned.");
        }
    }

    void Update()
    {
        // Check if both carController and speedText are assigned
        if (carController != null && speedText != null)
        {
            // Get the current speed in MPH (already calculated in CurrentSpeed property)
            float speed = carController.CurrentSpeed;

            // Update the speed text UI to display only in MPH
            speedText.text = "Speed: " + Mathf.RoundToInt(speed).ToString() + " MPH";
        }
    }
}