using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelOnKey : MonoBehaviour
{
    // Reference to the first panel (with the welcome message)
    public GameObject firstPanel;  // First panel with the welcome message
    private CanvasGroup canvasGroup; // CanvasGroup to control visibility

    void Start()
    {
        // Ensure the initial state of the first panel is visible
        if (firstPanel != null)
        {
            canvasGroup = firstPanel.GetComponent<CanvasGroup>(); // Get the CanvasGroup component
            if (canvasGroup == null)
            {
                // Add CanvasGroup if it doesn't exist
                canvasGroup = firstPanel.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 1f; // Make sure the panel is fully visible at the start
            canvasGroup.interactable = true; // Allow interactions
            canvasGroup.blocksRaycasts = true; // Ensure the panel blocks raycasts for input
            Debug.Log("First Panel (Welcome Message) is visible.");
        }
        else
        {
            Debug.LogError("First Panel (Welcome) is not assigned!");
        }
    }

    void Update()
    {
        // When M is pressed, hide the panel
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("M key pressed: Hiding panel.");
            HideFirstPanel();
        }

        // When N is pressed, bring the panel back
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("N key pressed: Bringing panel back.");
            ShowFirstPanel();
        }
    }

    // Hide the first panel (welcome message) by making it invisible but not inactive
    void HideFirstPanel()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f; // Set alpha to 0 (fully invisible)
            canvasGroup.interactable = false; // Disable interaction
            canvasGroup.blocksRaycasts = false; // Prevent blocking raycasts (input detection)
            Debug.Log("First Panel (Welcome Message) is now hidden.");
        }
        else
        {
            Debug.LogError("CanvasGroup component is missing on the first panel.");
        }
    }

    // Show the first panel (welcome message) by making it visible again
    void ShowFirstPanel()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f; // Set alpha to 1 (fully visible)
            canvasGroup.interactable = true; // Enable interaction
            canvasGroup.blocksRaycasts = true; // Allow raycast blocking (input detection)
            Debug.Log("First Panel (Welcome Message) is now visible.");
        }
        else
        {
            Debug.LogError("CanvasGroup component is missing on the first panel.");
        }
    }
}
