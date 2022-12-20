using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement movementScript;

    private float horizontalInput;
    private float verticalInput;

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

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyUp(KeyCode.E) && DialogSystem.instance.DialogIsWaitingToPlay())
        {
            DialogSystem.instance.DisplayDialog();
        }
    }

    public Vector2 GetMovementInputVector()
    {
        return new Vector2(horizontalInput, verticalInput);
    }
}
