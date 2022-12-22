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
    private EquipmentButton equipmentButton;
    
    
    
    public void Initialize(Item item)
    {
        equipmentButton = GetComponent<EquipmentButton>();
        
        itemName.text = item.itemName;
        itemImage.sprite = item.picture;
        itemData = item;

        equipmentButton.enabled = true;
    }

    public Item GetItemData()
    {
        return itemData;
    }

    public void ClearDisplay()
    {
        itemName.text = "";
        itemImage.sprite = null;
        itemData = null;
        
        equipmentButton.enabled = false;
    }
}
