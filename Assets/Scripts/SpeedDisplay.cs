using UnityEngine;
using TMPro; 
using EVP;
public class SpeedDisplay : MonoBehaviour
{
    public VehicleController vehicleController;  // Reference to the VehicleController script
    public TMP_Text speedText;

    void Update()
    {
        if (vehicleController != null && speedText != null)
        {
            float speed = vehicleController.GetComponent<Rigidbody>().velocity.magnitude * 2.23694f; // Convert m/s to mph
            speedText.text = speed.ToString("F1") + " mph";
        }
    }
}
