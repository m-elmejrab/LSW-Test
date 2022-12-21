using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingTrigger : ActionPromptTrigger
{
    private Dialog dialogToShow;
    private Inventory shopInventory;

    private void Start()
    {
        dialogToShow = GetComponent<Dialog>();
        shopInventory = GetComponent<Inventory>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        DialogSystem.instance.SetupDialogQueue(dialogToShow);
        ShoppingSystem.instance.SetupShoppingAfterDialog(shopInventory);
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        ShoppingSystem.instance.CancelShoppingAfterDialog();
    }
}
