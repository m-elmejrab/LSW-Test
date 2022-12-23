using UnityEngine;

public class ConfirmQuitButton : UIButton
{
    protected override void ClickHandler()
    {
        base.ClickHandler();
        Application.Quit();
    }
}
