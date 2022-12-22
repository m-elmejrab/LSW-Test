using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemImage;

    private Item itemData;
    
    
    public void Initialize(Item item)
    {
        itemName.text = item.itemName;
        itemImage.sprite = item.picture;

        itemData = item;
    }

    public Item GetItemData()
    {
        return itemData;
    }
}
