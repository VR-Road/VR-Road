using UnityEngine;
using UnityEngine.SceneManagement;
using VR_Road.InputSystem;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject menuCanvas;
    public TextMeshProUGUI menuText;
    
    private DrivingControls drivingControls;
    private bool menuActive = false;
    private int currentSelection = 0;
    private MenuState currentState = MenuState.Main;
    
    // Track previous input states for edge detection
    private bool prevDriveState = false;
    private bool prevReverseState = false;
    private bool prevAcceleratorState = false;
    private bool prevBrakeState = false;
    
    // To store original time scale
    private float originalTimeScale;
    
    private enum MenuState
    {
        Main,
        Tutorial,
        Scenes
    }
    
    private string[] mainMenuOptions = { "Tutorial", "Levels" };
    private string[] sceneNames = { "Start_scene", "Physical_skills", "Practice_no_traffic", "Practice_including_traffic", "Nighttime_practice", "Parking" };

    private void Awake()
    {
        drivingControls = new DrivingControls();
        drivingControls.Driving.Enable();
        menuCanvas.SetActive(false);
        UpdateMenuDisplay();
        originalTimeScale = Time.timeScale; // Store original time scale
    }
    
    private void OnEnable()
    {
        drivingControls.Driving.HomeButton.performed += _ => ToggleMenu();
    }
    
    private void OnDisable()
    {
        drivingControls.Driving.HomeButton.performed -= _ => ToggleMenu();
        // Ensure time scale is reset when disabled
        Time.timeScale = originalTimeScale;
    }

    private void OnDestroy()
    {
        // Clean up input callbacks when destroyed
        drivingControls.Driving.HomeButton.performed -= _ => ToggleMenu();
    }
    
    private void Update()
    {
        if (!menuActive) return;
        
        HandleMenuNavigation();
        HandleMenuSelection();
        HandleMenuBack();
    }
    
    private void ToggleMenu()
    {
        // Check if menu objects still exist
        if (menuCanvas == null || menuText == null)
        {
            drivingControls.Driving.HomeButton.performed -= _ => ToggleMenu();
            return;
        }

        menuActive = !menuActive;
        menuCanvas.SetActive(menuActive);
        
        if (menuActive)
        {
            // Freeze game when menu opens
            originalTimeScale = Time.timeScale; // Store current time scale
            Time.timeScale = 0f;
            
            currentState = MenuState.Main;
            currentSelection = 0;
            UpdateMenuDisplay();
        }
        else
        {
            // Unfreeze game when menu closes
            Time.timeScale = originalTimeScale;
        }
    }
    
    private void HandleMenuNavigation()
    {
        bool currentDriveState = drivingControls.Driving.DriveGear.ReadValue<float>() > 0.1f;
        bool currentReverseState = drivingControls.Driving.ReverseGear.ReadValue<float>() > 0.1f;
        
        // Drive gear pressed (rising edge)
        if (currentDriveState && !prevDriveState)
        {
            currentSelection = (currentSelection + 1) % GetCurrentMenuLength();
            UpdateMenuDisplay();
        }
        // Reverse gear pressed (rising edge)
        else if (currentReverseState && !prevReverseState)
        {
            currentSelection = (currentSelection - 1 + GetCurrentMenuLength()) % GetCurrentMenuLength();
            UpdateMenuDisplay();
        }
        
        prevDriveState = currentDriveState;
        prevReverseState = currentReverseState;
    }
    
    private void HandleMenuSelection()
    {
        bool currentAcceleratorState = drivingControls.Driving.AcceleratorPedal.ReadValue<float>() > 0.1f;
        
        // Accelerator pressed (rising edge)
        if (currentAcceleratorState && !prevAcceleratorState)
        {
            if (currentState == MenuState.Main)
            {
                if (currentSelection == 0) // Tutorial
                {
                    currentState = MenuState.Tutorial;
                }
                else // Scenes
                {
                    currentState = MenuState.Scenes;
                    currentSelection = 0;
                }
            }
            else if (currentState == MenuState.Scenes)
            {
                // Unfreeze before loading scene
                Time.timeScale = originalTimeScale;
                LoadScene(currentSelection);
                return;
            }
            
            UpdateMenuDisplay();
        }
        
        prevAcceleratorState = currentAcceleratorState;
    }
    
    private void HandleMenuBack()
    {
        bool currentBrakeState = drivingControls.Driving.BrakePedal.ReadValue<float>() > 0.1f;
        
        // Brake pressed (rising edge)
        if (currentBrakeState && !prevBrakeState)
        {
            if (currentState != MenuState.Main)
            {
                currentState = MenuState.Main;
                currentSelection = 0;
                UpdateMenuDisplay();
            }
            else
            {
                // Close menu if already at main menu
                ToggleMenu();
            }
        }
        
        prevBrakeState = currentBrakeState;
    }
    
    private int GetCurrentMenuLength()
    {
        return currentState switch
        {
            MenuState.Main => mainMenuOptions.Length,
            MenuState.Scenes => sceneNames.Length,
            _ => 1
        };
    }
    
    private void UpdateMenuDisplay()
    {
        string menuContent = "";
        
        switch (currentState)
        {
            case MenuState.Main:
                menuContent = "<b>MAIN MENU USE THIS TO NAVIGATE THROUGH LEVELS</b>\n\n";
                for (int i = 0; i < mainMenuOptions.Length; i++)
                {
                    menuContent += (i == currentSelection) ? $"<b>> {mainMenuOptions[i]}</b>\n" : $"  {mainMenuOptions[i]}\n";
                }
                menuContent += "\n<i>Brake: Close Menu Accelerate: Select</i>";
                break;
                
            case MenuState.Tutorial:
                menuContent = "<b>TUTORIAL</b>\n\n" +
                             "CONTROLS:\n\n" +
                             "DRIVE GEAR: Move down\n" +
                             "REVERSE GEAR: Move up\n" +
                             "ACCELERATOR: Confirm\n" +
                             "BRAKE PEDAL: Back\n" +
                             "HOME BUTTON: Toggle menu\n\n" +
                             "<i>Press brake to return</i>";
                break;
                
            case MenuState.Scenes:
                menuContent = "<b>SELECT LEVEL</b>\n\n";
                
                for (int i = 0; i < sceneNames.Length; i++)
                {
                    menuContent += (i == currentSelection) ? $"<b>> {sceneNames[i]}</b>\n" : $"  {sceneNames[i]}\n";
                }
                menuContent += "\n<i>Accelerator: Select | Brake: Back</i>";
                break;
        }
        
        menuText.text = menuContent;
    }
    
    private void LoadScene(int sceneIndex)
    {
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            DynamicGI.UpdateEnvironment(); 
            SceneManager.LoadScene(sceneIndex);
            DynamicGI.UpdateEnvironment();
        }
    }
}