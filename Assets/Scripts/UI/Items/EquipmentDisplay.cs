using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplay : MonoBehaviour
{
    private Item itemData;
    private EquipmentButton equipmentButton;
    
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemImage;

    public void Initialize(Item item)
    {
        equipmentButton = GetComponent<EquipmentButton>();
        
        itemName.text = item.itemName;
        itemImage.sprite = item.sprite;
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
