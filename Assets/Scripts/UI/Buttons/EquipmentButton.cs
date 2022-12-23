using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentButton : UIButton
{
    public event Action<Item> EquipmentButtonClicked;
    protected override void ClickHandler()
    {
        SoundManager.instance.PlayAudioClip("equip");
        EquipmentButtonClicked?.Invoke(GetComponent<EquipmentDisplay>().GetItemData());
    }
}
