using UnityEngine;
using Cinemachine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel; // Drag your InventoryPanel here in the inspector
    private bool isInventoryOpen = false;

    public CinemachineFreeLook cinemachineFreeLook;

    void Start()
    {
        // Initialize with inventory closed
        inventoryPanel.SetActive(false);
        isInventoryOpen = false;
        if (cinemachineFreeLook != null)
        {
            cinemachineFreeLook.enabled = true;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        
    }

    public void ToggleInventory()
    {
        
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
        ToggleCursorState();

        if (cinemachineFreeLook != null)
        {
            cinemachineFreeLook.enabled = !isInventoryOpen;
        }
        else
        {
            Debug.LogError("Cinemachine cam script reference is not assigned in InventoryToggle.");
        }
    }

    private void ToggleCursorState()
    {
        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}