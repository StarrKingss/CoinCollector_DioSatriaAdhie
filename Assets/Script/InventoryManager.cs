using UnityEngine; 
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    InputAction inventoryAction;
    [SerializeField] private GameObject InventoryCanvas;
    private bool InventoryActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryAction = InputSystem.actions.FindAction("Inventory");
        InventoryCanvas.SetActive(false);
        InventoryActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryAction.triggered && InventoryCanvas != null && InventoryActive == false)
        {
            InventoryCanvas.SetActive(true);
            InventoryActive = true;
            Time.timeScale = 0f;
            Debug.Log("Inventory Opened");
        }
        else if (inventoryAction.triggered && InventoryCanvas != null && InventoryActive == true)
        {
            InventoryCanvas.SetActive(false);
            InventoryActive = false;
            Time.timeScale = 1f;
        }
    }
}
