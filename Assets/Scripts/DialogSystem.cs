using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : SingletonOneScene<DialogSystem>
{

   private PlayerManager playerManager;
   
   [SerializeField] private GameObject actionPromptBox;
   [SerializeField] private TextMeshProUGUI promptText;

   [SerializeField] private GameObject dialogBox;
   [SerializeField] private TextMeshProUGUI dialogSpeaker;
   [SerializeField] private TextMeshProUGUI dialogText;


   private void Start()
   {
      playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
   }

   public void DisplayActionPrompt(string prompt)
   {
      actionPromptBox.SetActive(true);
      promptText.text = prompt;
   }
   
   public void HideActionPrompt()
   {
      actionPromptBox.SetActive(false);
   }

   public void DisplayDialog() //Add dialog class
   {
      
   }

   private void HideDialog()
   {
      
   }
}
