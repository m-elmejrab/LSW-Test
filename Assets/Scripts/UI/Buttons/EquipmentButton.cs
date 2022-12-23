using System;

public class EquipmentButton : UIButton
{
    public event Action<Item> EquipmentButtonClicked;
    protected override void ClickHandler()
    {
        SoundManager.instance.PlayAudioClip("equip");
        EquipmentButtonClicked?.Invoke(GetComponent<EquipmentDisplay>().GetItemData());
    }
}
