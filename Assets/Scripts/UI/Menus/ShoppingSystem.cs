using UnityEngine;

public class ShoppingSystem : SingletonOneScene<ShoppingSystem>
{
    private Inventory shopInventory;
    
    [SerializeField] private GameObject shoppingWindow;

    private void Start()
    {
        shoppingWindow.SetActive(false);
    }

    public void SetupShoppingAfterDialog(Inventory shoppingInventory)
    {
        DialogSystem.instance.DialogCompleted += StartShopping;
        shopInventory = shoppingInventory;
    }
    
    public void CancelShoppingAfterDialog()
    {
        DialogSystem.instance.DialogCompleted -= StartShopping;
    }

    private void StartShopping()
    {
        shoppingWindow.SetActive(true);
        shoppingWindow.GetComponent<ShoppingMenuController>().Initialize(shopInventory);
        GameManager.instance.DisablePlayerMovement();
    }

    public void EndShopping()
    {
        shoppingWindow.SetActive(false);
        GameManager.instance.EnablePlayerMovement();
    }
}
