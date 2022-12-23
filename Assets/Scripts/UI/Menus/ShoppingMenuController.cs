using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingMenuController : MonoBehaviour
{
    private Inventory playerInitialInventory;
    private Inventory shopInitialInventory;
    
    private Inventory playerTempInventory;
    private Inventory shopTempInventory;
    
    [SerializeField] private GameObject itemDisplayTemplate;
    [SerializeField] private GridLayoutGroup playerInterface;
    [SerializeField] private GridLayoutGroup shopInterface;
    [SerializeField] private TextMeshProUGUI playerFundsText;
    [SerializeField] private TextMeshProUGUI shopFundsText;
    [SerializeField] private ConfirmShoppingButton confirmButton;
    [SerializeField] private CancelShoppingButton cancelButton;
    [SerializeField] private GameObject fundsWarningTextContainer;
    
    public void Initialize(Inventory shopInventory)
    {
        shopInitialInventory = shopInventory;
        playerInitialInventory = GameManager.instance.GetReferenceToPlayer().GetComponent<Inventory>();

        playerTempInventory = new GameObject().AddComponent<Inventory>();
        playerTempInventory.SetAllInventoryData(playerInitialInventory.GetCurrentlyHeldItems(), playerInitialInventory.GetRemainingMoney());
        shopTempInventory = new GameObject().AddComponent<Inventory>();
        shopTempInventory.SetAllInventoryData(shopInitialInventory.GetCurrentlyHeldItems(), shopInitialInventory.GetRemainingMoney());
        
        confirmButton.ConfirmButtonClicked += ConfirmButtonClicked;
        cancelButton.CancelButtonClicked += CancelButtonClicked;
        fundsWarningTextContainer.SetActive(false);
        
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
        }
        else
        {
            StartCoroutine(DisplayFundsWarning());
        }
    }

    private void OnSellingItemClicked(Item clickedItem)
    {
        if (shopTempInventory.HasEnoughMoney(clickedItem.price))
        {
            shopTempInventory.AddItem(clickedItem);
            playerTempInventory.RemoveItem(clickedItem);
            RefreshInterface();
        }
        else
        {
            StartCoroutine(DisplayFundsWarning());
        }
    }

    private IEnumerator DisplayFundsWarning()
    {
        fundsWarningTextContainer.SetActive(true);
        yield return new WaitForSeconds(2f);
        fundsWarningTextContainer.SetActive(false);
    }
}
