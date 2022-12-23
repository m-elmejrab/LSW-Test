using System;

public class MainMenuButton : UIButton
{
    public event Action ButtonWasPressed;

    protected override void ClickHandler()
    {
        base.ClickHandler();
        ButtonWasPressed?.Invoke();
    }

    public void DisableButton()
    {
        myButton.interactable = false;
    }

    public void EnableButton()
    {
        myButton.interactable = true;
    }
}
