using UnityEngine;
using VR_Road.InputSystem;
using TMPro;

public class IntroManager : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject introCanvas; // The canvas holding the intro text

    private DrivingControls drivingControls;
    private int currentPage = 0;
    private bool menuOpen = false;

    private string[] introPages = {
        "Welcome to VR_Road!\n\nThis immersive driving simulator is designed to help you learn and practice essential driving skills in a safe, virtual environment.",
        
        "Navigating Instructions:\n\nUse the ACCELERATOR pedal to move forward through instructions.\nUse the BRAKE pedal to move backward if you want to review a previous section.",

        "Driving Controls Overview:\n\n- Steering Wheel: Steer\n- Drive Gear: Move Forward\n- Reverse Gear: Move Backward\n- Brake Pedal: Stop\n- Accelerator Pedal: Accelerate",
        
        "Take your time and enjoy the experience.\n\nWhen you're ready, press the HOME button in the center of the wheel to open the menu, and navigate to the 'Physical Skills' level.\n\nRelax and have fun learning at VR_Road!"
    };

    private bool prevAcceleratorState = false;
    private bool prevBrakeState = false;

    private void Awake()
    {
        drivingControls = new DrivingControls();
        drivingControls.Driving.Enable();
        UpdateIntroText();
    }

    private void OnEnable()
    {
        drivingControls.Driving.HomeButton.performed += _ => ToggleMenu();
    }

    private void OnDisable()
    {
        drivingControls.Driving.HomeButton.performed -= _ => ToggleMenu();
    }

    private void Update()
    {
        if (!menuOpen)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        bool currentAcceleratorState = drivingControls.Driving.AcceleratorPedal.ReadValue<float>() > 0.1f;
        bool currentBrakeState = drivingControls.Driving.BrakePedal.ReadValue<float>() > 0.1f;

        // Press Accelerator to go forward
        if (currentAcceleratorState && !prevAcceleratorState)
        {
            currentPage = Mathf.Min(currentPage + 1, introPages.Length - 1);
            UpdateIntroText();
        }

        // Press Brake to go backward
        if (currentBrakeState && !prevBrakeState)
        {
            currentPage = Mathf.Max(currentPage - 1, 0);
            UpdateIntroText();
        }

        prevAcceleratorState = currentAcceleratorState;
        prevBrakeState = currentBrakeState;
    }

    private void UpdateIntroText()
    {
        if (introCanvas != null && currentPage >= 0 && currentPage < introPages.Length)
        {
            string navigationInstructions = "\n\n<i>Press Accelerator to continue | Press Brake to go back</i>";
            introCanvas.GetComponentInChildren<TextMeshProUGUI>().text = introPages[currentPage] + navigationInstructions;
        }
    }

    private void ToggleMenu()
    {
        menuOpen = !menuOpen;

        if (menuOpen)
        {
            introCanvas.SetActive(false); // Hide intro when menu opens
        }
        else
        {
            introCanvas.SetActive(true); // Show intro again if menu closes
        }
    }

    private void OnDestroy()
    {
        drivingControls.Driving.Disable();
    }
}
