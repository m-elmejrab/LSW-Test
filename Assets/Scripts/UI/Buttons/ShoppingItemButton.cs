using System;

public class ShoppingItemButton : UIButton
{
    public event Action<Item> ShoppingButtonClicked;
    protected override void ClickHandler()
    {
        base.ClickHandler();
        ShoppingButtonClicked?.Invoke(GetComponent<ItemDisplay>().GetItemData());
    }
}
