using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemImage;

    private Item itemData;
    
    
    public void Initialize(Item item)
    {
        itemName.text = item.itemName;
        itemPrice.text = item.price.ToString();
        itemImage.sprite = item.sprite;

        itemData = item;
    }

    public Item GetItemData()
    {
        return itemData;
    }
}