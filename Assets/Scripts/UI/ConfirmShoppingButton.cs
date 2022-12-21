using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmShoppingButton : UIButton
{
    public event Action ConfirmButtonClicked;
    protected override void ClickHandler()
    {
        ConfirmButtonClicked?.Invoke();
    }
}
