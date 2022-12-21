using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPromptTrigger : MonoBehaviour //Base class for all triggers
{
    [SerializeField] private string prompt;

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            DialogSystem.instance.DisplayActionPrompt(prompt);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        DialogSystem.instance.HideActionPrompt();
    }
}