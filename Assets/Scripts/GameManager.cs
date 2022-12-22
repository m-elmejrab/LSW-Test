using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private bool gameIsPaused = false;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                gameIsPaused = true;
                Time.timeScale = 0f;
                UISystem.instance.DisplayPauseMenu();
            }
            else
            {
                gameIsPaused = false;
                Time.timeScale = 1f;
                UISystem.instance.HidePauseMenu();
            }
        }
    }

    public void DisablePlayerMovement()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        
    }

    public void EnablePlayerMovement()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    public GameObject GetReferenceToPlayer()
    {
        return player;
    }
}
