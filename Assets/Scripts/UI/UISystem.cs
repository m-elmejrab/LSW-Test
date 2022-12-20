using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : SingletonOneScene<UISystem>
{
   [SerializeField] private GameObject mainMenuObject;

   private void Start()
   {
      mainMenuObject.SetActive(false);
   }

   public void DisplayPauseMenu()
   {
      mainMenuObject.SetActive(true);
   }

   public void HidePauseMenu()
   {
      mainMenuObject.SetActive(false);
   }
}
