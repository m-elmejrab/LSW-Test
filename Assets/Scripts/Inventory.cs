using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int moneyAvailable;
    [SerializeField] private List<Item> itemsHeld;

    public bool HasEnoughMoney(int costRequired)
    {
        return moneyAvailable - costRequired >= 0;
    }

    public void AddItem(Item itemToAdd)
    {
        itemsHeld.Add(itemToAdd);
        moneyAvailable -= itemToAdd.price;
    }

    public void RemoveItem(Item itemToRemove)
    {
        itemsHeld.Remove(itemToRemove);
        moneyAvailable += itemToRemove.price;
    }

    public List<Item> GetCurrentlyHeldItems()
    {
        return itemsHeld;
    }

    public int GetRemainingMoney()
    {
        return moneyAvailable;
    }

    public void SetAllInventoryData(List<Item> items, int funds)
    {
        itemsHeld = new List<Item>(items);
        moneyAvailable = funds;

    }
}
