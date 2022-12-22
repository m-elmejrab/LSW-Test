using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenuController : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup weaponsContainer;
    [SerializeField] private GridLayoutGroup helmetsContainer;
    [SerializeField] private GameObject equipmentDisplayPrefab;
    [SerializeField] private EquipmentDisplay weaponSlotDisplay;
    [SerializeField] private EquipmentDisplay helmetSlotDisplay;

    private PlayerEquipment playerEquipment;

    private Item equippedWeapon;
    private Item equippedHelmet;

    private void Start()
    {
        weaponSlotDisplay.gameObject.GetComponent<EquipmentButton>().EquipmentButtonClicked += OnEquipmentButtonClicked;
        helmetSlotDisplay.gameObject.GetComponent<EquipmentButton>().EquipmentButtonClicked += OnEquipmentButtonClicked;
    }

    public void Initialize()
    {
        playerEquipment = GameManager.instance.GetReferenceToPlayer().GetComponent<PlayerEquipment>();


        RefreshInterface();
    }

    private void RefreshInterface()
    {
        if (weaponsContainer.transform.childCount > 0)
        {
            for (int i = 0; i < weaponsContainer.transform.childCount; i++)
            {
                GameObject child = weaponsContainer.transform.GetChild(i).gameObject;
                child.GetComponent<EquipmentButton>().EquipmentButtonClicked -= OnEquipmentButtonClicked;
                Destroy(child);
            }
        }

        if (helmetsContainer.transform.childCount > 0)
        {
            for (int i = 0; i < helmetsContainer.transform.childCount; i++)
            {
                //Destroy(helmetsContainer.transform.GetChild(i).gameObject);
                GameObject child = helmetsContainer.transform.GetChild(i).gameObject;
                child.GetComponent<EquipmentButton>().EquipmentButtonClicked -= OnEquipmentButtonClicked;
                Destroy(child);
            }
        }

        PopulateEquipmentInterface();
        Debug.Log("Refresh requested");
    }

    private void PopulateEquipmentInterface()
    {
        List<Item> currentlyHeldEquipment = playerEquipment.GetUnusedEquipment();

        if (currentlyHeldEquipment.Count > 0)
        {
            for (int i = 0; i < currentlyHeldEquipment.Count; i++)
            {
                switch (currentlyHeldEquipment[i].type)
                {
                    case Item.ItemType.Weapon:
                        GameObject newWeapon = Instantiate(equipmentDisplayPrefab, weaponsContainer.transform);
                        newWeapon.GetComponent<EquipmentDisplay>().Initialize(currentlyHeldEquipment[i]);
                        newWeapon.GetComponent<EquipmentButton>().EquipmentButtonClicked += OnEquipmentButtonClicked;
                        break;

                    case Item.ItemType.Helmet:
                        GameObject newHelmet = Instantiate(equipmentDisplayPrefab, helmetsContainer.transform);
                        newHelmet.GetComponent<EquipmentDisplay>().Initialize(currentlyHeldEquipment[i]);
                        newHelmet.GetComponent<EquipmentButton>().EquipmentButtonClicked += OnEquipmentButtonClicked;
                        break;
                }
            }
        }


        equippedWeapon = playerEquipment.GetEquippedItem(Item.ItemType.Weapon);
        if (equippedWeapon != null)
            weaponSlotDisplay.Initialize(equippedWeapon);

        equippedHelmet = playerEquipment.GetEquippedItem(Item.ItemType.Helmet);
        if (equippedHelmet != null)
            helmetSlotDisplay.Initialize(equippedHelmet);
    }

    private void OnEquipmentButtonClicked(Item clickedItem)
    {
        if (clickedItem != null)
        {
            switch (clickedItem.type)
            {
                case Item.ItemType.Helmet:
                    if (equippedHelmet != null && clickedItem == equippedHelmet)
                    {
                        playerEquipment.UnequipItem(clickedItem);
                        helmetSlotDisplay.ClearDisplay();
                        equippedHelmet = null;
                    }
                    else
                    {
                        playerEquipment.EquipItem(clickedItem);
                    }

                    break;

                case Item.ItemType.Weapon:
                    if (equippedWeapon != null && clickedItem == equippedWeapon)
                    {
                        playerEquipment.UnequipItem(clickedItem);
                        weaponSlotDisplay.ClearDisplay();
                        equippedWeapon = null;
                    }
                    else
                    {
                        playerEquipment.EquipItem(clickedItem);
                    }

                    break;
            }

            RefreshInterface();
        }
    }
}