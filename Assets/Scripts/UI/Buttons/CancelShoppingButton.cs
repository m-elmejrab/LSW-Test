using System;

public class CancelShoppingButton : UIButton
{
    public event Action CancelButtonClicked;
    
    protected override void ClickHandler()
    {
        base.ClickHandler();
        CancelButtonClicked?.Invoke();
    }
}
