using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private bool initialPreparationSkipped = false; //Trying to refresh UI on the game's load leads to error, skips first frame and loads after

    [SerializeField] private MainMenuButton quitButton;
    [SerializeField] private MainMenuButton inventoryButton;
    [SerializeField] private GameObject quitInterface;
    [SerializeField] private GameObject inventoryInterface;
    [SerializeField] private EquipmentMenuController equipmentMenuController;
    
    private void Awake()
    {
        quitButton.ButtonWasPressed += QuitButtonOnButtonWasPressed;
        inventoryButton.ButtonWasPressed += InventoryButtonOnButtonWasPressed;
        
        quitInterface.SetActive(false);
        inventoryInterface.SetActive(true);
    }

    private void InventoryButtonOnButtonWasPressed()
    {
        inventoryButton.DisableButton(); 
        quitButton.EnableButton();
        inventoryInterface.SetActive(true);
        quitInterface.SetActive(false);
        
        equipmentMenuController.Initialize();
    }

    private void QuitButtonOnButtonWasPressed()
    {
        inventoryButton.EnableButton();
        quitButton.DisableButton();
        inventoryInterface.SetActive(false);
        quitInterface.SetActive(true);
    }

    private void OnEnable()
    {
        if (initialPreparationSkipped)
        {
            equipmentMenuController.Initialize();
        }
        else
        {
            initialPreparationSkipped = true;
        }
    }
}
