using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingItemButton : UIButton
{
    public event Action<Item> ShoppingButtonClicked;
    protected override void ClickHandler()
    {
        ShoppingButtonClicked?.Invoke(GetComponent<ItemDisplay>().GetItemData());
    }
}
