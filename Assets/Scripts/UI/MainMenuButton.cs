using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : UIButton
{
    public event Action ButtonWasPressed;

    protected override void ClickHandler()
    {
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
