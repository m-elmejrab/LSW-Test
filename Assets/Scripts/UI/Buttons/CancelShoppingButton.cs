using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelShoppingButton : UIButton
{
    public event Action CancelButtonClicked;
    
    protected override void ClickHandler()
    {
        base.ClickHandler();
        CancelButtonClicked?.Invoke();
    }
}
