using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPromptTrigger : MonoBehaviour
{
    [SerializeField] private string prompt;
    [SerializeField] private bool actionIsDialog;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (actionIsDialog)
            {
                Dialog dialogToShow = GetComponent<Dialog>();
                DialogSystem.instance.DisplayActionPrompt(prompt, true, dialogToShow);
            }
            else
            {
                DialogSystem.instance.DisplayActionPrompt(prompt, false, null);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DialogSystem.instance.HideActionPrompt();
    }
}