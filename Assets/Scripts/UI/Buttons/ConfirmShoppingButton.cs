using System;

public class ConfirmShoppingButton : UIButton
{
    public event Action ConfirmButtonClicked;
    protected override void ClickHandler()
    {
        base.ClickHandler();
        ConfirmButtonClicked?.Invoke();
    }
}
