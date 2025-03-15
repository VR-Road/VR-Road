using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public Canvas menuCanvas; // Reference to the Canvas you want to toggle

    void Update()
    {
        // Check if the M key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleCanvas();
        }
    }

    // Toggle the Canvas visibility
    void ToggleCanvas()
    {
        if (menuCanvas != null)
        {
            menuCanvas.enabled = !menuCanvas.enabled; // Toggle the Canvas
        }
        else
        {
            Debug.LogError("Menu Canvas is not assigned.");
        }
    }
}