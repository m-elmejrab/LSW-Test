using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private bool gameIsPaused = false;
    
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
}
