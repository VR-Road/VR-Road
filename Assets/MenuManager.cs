using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VR_Road.InputSystem;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject menuCanvas;
    public TextMeshProUGUI menuText;
    
    [Header("Input Settings")]
    [Range(0.8f, 0.99f)]
    public float steeringDeadzone = 0.9f;
    public float inputCooldown = 0.3f;
    
    private DrivingControls drivingControls;
    private bool menuActive = false;
    private float lastInputTime;
    private int currentSelection = 0;
    private MenuState currentState = MenuState.Main;
    
    private enum MenuState
    {
        Main,
        Tutorial,
        Scenes
    }
    
    private string[] mainMenuOptions = { "Tutorial", "Scenes" };
    private string[] sceneNames = { "Physical_skills", "Practice_no_traffic", "Practice_including_traffic", "Nighttime_practice", "Parking" }; // Update with your scene names

    private void Awake()
    {
        drivingControls = new DrivingControls();
        drivingControls.Driving.Enable();
        
        // Hide menu initially
        menuCanvas.SetActive(false);
        UpdateMenuDisplay();
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
        if (!menuActive) return;
        
        HandleMenuNavigation();
        HandleMenuSelection();
    }
    
    private void ToggleMenu()
    {
        menuActive = !menuActive;
        menuCanvas.SetActive(menuActive);
        
        if (menuActive)
        {
            // Reset to main menu when opening
            currentState = MenuState.Main;
            currentSelection = 0;
            UpdateMenuDisplay();
        }
    }
    
    private void HandleMenuNavigation()
    {
        if (Time.time - lastInputTime < inputCooldown) return;
        
        float steeringInput = drivingControls.Driving.Steering.ReadValue<float>();
        steeringInput *= -1; // Invert to match your input system
        
        // Check for left/right navigation
        if (steeringInput > steeringDeadzone)
        {
            // Right turn - move down
            if (currentState == MenuState.Main)
            {
                currentSelection = (currentSelection + 1) % mainMenuOptions.Length;
            }
            else if (currentState == MenuState.Scenes)
            {
                currentSelection = (currentSelection + 1) % sceneNames.Length;
            }
            
            UpdateMenuDisplay();
            lastInputTime = Time.time;
        }
        else if (steeringInput < -steeringDeadzone)
        {
            // Left turn - move up
            if (currentState == MenuState.Main)
            {
                currentSelection = (currentSelection - 1 + mainMenuOptions.Length) % mainMenuOptions.Length;
            }
            else if (currentState == MenuState.Scenes)
            {
                currentSelection = (currentSelection - 1 + sceneNames.Length) % sceneNames.Length;
            }
            
            UpdateMenuDisplay();
            lastInputTime = Time.time;
        }
    }
    
    private void HandleMenuSelection()
    {
        // Use accelerator pedal as "Enter"
        float acceleratorInput = drivingControls.Driving.AcceleratorPedal.ReadValue<float>();
        
        if (acceleratorInput > 0.1f && Time.time - lastInputTime > inputCooldown)
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
                LoadScene(currentSelection);
                return; // Don't update display since we're changing scenes
            }
            else // In tutorial, any selection returns to main menu
            {
                currentState = MenuState.Main;
            }
            
            UpdateMenuDisplay();
            lastInputTime = Time.time;
        }
    }
    
    private void UpdateMenuDisplay()
    {
        string menuContent = "";
        
        switch (currentState)
        {
            case MenuState.Main:
                menuContent = "<b>MAIN MENU</b>\n\n";
                for (int i = 0; i < mainMenuOptions.Length; i++)
                {
                    if (i == currentSelection)
                        menuContent += "<b>> " + mainMenuOptions[i] + "</b>\n";
                    else
                        menuContent += "  " + mainMenuOptions[i] + "\n";
                }
                break;
                
            case MenuState.Tutorial:
                menuContent = "<b>TUTORIAL</b>\n\n" +
                             "HOW TO USE THIS SIMULATION:\n\n" +
                             "1. STEERING WHEEL: Turn left/right to navigate menus\n" +
                             "2. ACCELERATOR PEDAL: Press to select menu options\n" +
                             "3. HOME BUTTON: Toggles the menu on/off\n\n" +
                             "DRIVING CONTROLS:\n" +
                             "- Steering Wheel: Turn to control vehicle\n" +
                             "- Accelerator: Right pedal to go forward\n" +
                             "- Brake: Left pedal to slow down\n" +
                             "- Gear Paddles: Change gears\n\n" +
                             "<i>Press accelerator to return</i>";
                break;
                
            case MenuState.Scenes:
                menuContent = "<b>SELECT SCENE</b>\n\n";
                for (int i = 0; i < sceneNames.Length; i++)
                {
                    if (i == currentSelection)
                        menuContent += "<b>> " + sceneNames[i] + "</b>\n";
                    else
                        menuContent += "  " + sceneNames[i] + "\n";
                }
                menuContent += "\n<i>Press accelerator to select</i>";
                break;
        }
        
        menuText.text = menuContent;
    }
    
    private void LoadScene(int sceneIndex)
    {
        // Assuming you have scenes set up in your build settings
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}