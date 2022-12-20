using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPromptTrigger : MonoBehaviour
{
    [SerializeField] private string prompt;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            DialogSystem.instance.DisplayActionPrompt(prompt);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DialogSystem.instance.HideActionPrompt();
    }
}