using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuButton quitButton;
    [SerializeField] private MainMenuButton inventoryButton;

    [SerializeField] private GameObject quitInterface;
    [SerializeField] private GameObject inventoryInterface;

    private void Start()
    {
        quitButton.ButtonWasPressed += QuitButtonOnButtonWasPressed;
        inventoryButton.ButtonWasPressed += InventoryButtonOnButtonWasPressed;
        
        quitInterface.SetActive(false);
        inventoryInterface.SetActive(false);
    }

    private void InventoryButtonOnButtonWasPressed()
    {
        inventoryButton.DisableButton(); 
        quitButton.EnableButton();
        
        inventoryInterface.SetActive(true);
        quitInterface.SetActive(false);
    }

    private void QuitButtonOnButtonWasPressed()
    {
        inventoryButton.EnableButton();
        quitButton.DisableButton();
        
        inventoryInterface.SetActive(false);
        quitInterface.SetActive(true);
        
    }
}
