using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private Item equippedWeapon;
    private Item equippedHelm;

    private List<Item> otherEquipment;

    public void EquipItem(Item item)
    {
        switch (item.type)
        {
            case Item.ItemType.Weapon:
    
                if (equippedWeapon == null)
                {
                    equippedWeapon = item;
                    otherEquipment.Remove(item);
                }
                else
                {
                    otherEquipment.Add(equippedWeapon);
                    equippedWeapon = item;
                    otherEquipment.Remove(item);
                }

                break;

            case Item.ItemType.Helmet:
                if (equippedHelm == null)
                {
                    equippedHelm = item;
                    otherEquipment.Remove(item);
                }
                else
                {
                    otherEquipment.Add(equippedHelm);
                    equippedHelm = item;
                    otherEquipment.Remove(item);
                }

                break;
        }
    }

    public void UnequipItem(Item itemToUnequip)
    {
        switch (itemToUnequip.type)
        {
            case Item.ItemType.Weapon:
                otherEquipment.Add(equippedWeapon);
                equippedWeapon = null;
                break;

            case Item.ItemType.Helmet:
                otherEquipment.Add(equippedHelm);
                equippedHelm = null;
                break;
        }
    }

    public Item GetEquippedItem(Item.ItemType typeRequested)
    {
        switch (typeRequested)
        {
            case Item.ItemType.Weapon:
                return equippedWeapon;

            case Item.ItemType.Helmet:
                return equippedHelm;
        }

        return null;
    }
}