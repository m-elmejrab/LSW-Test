using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingMenuController : MonoBehaviour
{
    [SerializeField] private GameObject itemDisplayTemplate;
    [SerializeField] private GridLayoutGroup playerInterface;
    [SerializeField] private GridLayoutGroup shopInterface;
    [SerializeField] private TextMeshProUGUI playerFundsText;
    [SerializeField] private TextMeshProUGUI shopFundsText;
    [SerializeField] private ConfirmShoppingButton confirmButton;
    [SerializeField] private CancelShoppingButton cancelButton;

    private Inventory playerInitialInventory;
    private Inventory shopInitialInventory;

    private Inventory playerTempInventory;
    private Inventory shopTempInventory;
    
    public void Initialize(Inventory shopInventory)
    {
        shopInitialInventory = shopInventory;
        playerInitialInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        playerTempInventory = new GameObject().AddComponent<Inventory>();
        playerTempInventory.SetAllInventoryData(playerInitialInventory.GetCurrentlyHeldItems(), playerInitialInventory.GetRemainingMoney());
        
        shopTempInventory = new GameObject().AddComponent<Inventory>();
        shopTempInventory.SetAllInventoryData(shopInitialInventory.GetCurrentlyHeldItems(), shopInitialInventory.GetRemainingMoney());
        
        confirmButton.ConfirmButtonClicked += ConfirmButtonClicked;
        cancelButton.CancelButtonClicked += CancelButtonClicked;
        
        RefreshInterface();

    }

    private void CancelButtonClicked()
    {
        Destroy(shopTempInventory.gameObject);
        Destroy(playerTempInventory.gameObject);
        
        ShoppingSystem.instance.EndShopping();
    }

    private void ConfirmButtonClicked()
    {
        playerInitialInventory.SetAllInventoryData(playerTempInventory.GetCurrentlyHeldItems(), playerTempInventory.GetRemainingMoney());
        shopInitialInventory.SetAllInventoryData(shopTempInventory.GetCurrentlyHeldItems(), shopTempInventory.GetRemainingMoney());
        
        Destroy(shopTempInventory.gameObject);
        Destroy(playerTempInventory.gameObject);
        
        
        ShoppingSystem.instance.EndShopping();
    }

    private void RefreshInterface()
    {
        if (playerInterface.transform.childCount > 0)
        {
            for (int i = 0; i < playerInterface.transform.childCount; i++)
                Destroy(playerInterface.transform.GetChild(i).gameObject);
        }
        
        if (shopInterface.transform.childCount > 0)
        {
            for (int i = 0; i < shopInterface.transform.childCount; i++)
                Destroy(shopInterface.transform.GetChild(i).gameObject);
        }

        List<Item> playerItems = playerTempInventory.GetCurrentlyHeldItems();

        for (int i = 0; i < playerItems.Count; i++)
        {
            GameObject newItem = Instantiate(itemDisplayTemplate, playerInterface.transform);
            newItem.GetComponent<ItemDisplay>().Initialize(playerItems[i]);
            newItem.GetComponent<ShoppingItemButton>().ShoppingButtonClicked += OnSellingItemClicked;
        }

        List<Item> shopItems = shopTempInventory.GetCurrentlyHeldItems();

        for (int i = 0; i < shopItems.Count; i++)
        {
            GameObject newItem = Instantiate(itemDisplayTemplate, shopInterface.transform);
            newItem.GetComponent<ItemDisplay>().Initialize(shopItems[i]);
            newItem.GetComponent<ShoppingItemButton>().ShoppingButtonClicked += OnBuyingItemClicked;
        }

        playerFundsText.text = playerTempInventory.GetRemainingMoney().ToString();
        shopFundsText.text = shopTempInventory.GetRemainingMoney().ToString();

    }

    private void OnBuyingItemClicked(Item clickedItem)
    {
        if (playerTempInventory.HasEnoughMoney(clickedItem.price))
        {
            playerTempInventory.AddItem(clickedItem);
            shopTempInventory.RemoveItem(clickedItem);
            RefreshInterface();
            Debug.Log($"Player Money {playerTempInventory.GetRemainingMoney()} , and Shop funds {shopTempInventory.GetRemainingMoney()}");
        }
        else
        {
            Debug.Log("not enough money");
        }
    }

    private void OnSellingItemClicked(Item clickedItem)
    {
        if (shopTempInventory.HasEnoughMoney(clickedItem.price))
        {
            shopTempInventory.AddItem(clickedItem);
            playerTempInventory.RemoveItem(clickedItem);
            RefreshInterface();
            Debug.Log($"Player Money {playerTempInventory.GetRemainingMoney()} , and Shop funds {shopTempInventory.GetRemainingMoney()}");
        }
        else
        {
            Debug.Log("not enough money");
        }
    }
}