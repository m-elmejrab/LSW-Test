using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement movementScript;

    private void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
    }

    public void DisablePlayerMovement()
    {
        movementScript.enabled = false;
    }

    public void EnablePlayerMovement()
    {
        movementScript.enabled = true;
    }
}
