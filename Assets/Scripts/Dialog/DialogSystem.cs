using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : SingletonOneScene<DialogSystem>
{

   private Dialog nextDialogToShow;
   private bool dialogReadyToPlay = false;
   private int indexOfSentenceToDisplay = -1;

   [SerializeField] private GameObject actionPromptBox;
   [SerializeField] private TextMeshProUGUI promptText;

   [SerializeField] private GameObject dialogBox;
   [SerializeField] private TextMeshProUGUI dialogSpeaker;
   [SerializeField] private TextMeshProUGUI dialogText;

   public event Action DialogCompleted;


   private void Start()
   {
      actionPromptBox.SetActive(false);
      dialogBox.SetActive(false);
   }

   public void DisplayActionPrompt(string prompt)
   {
      actionPromptBox.SetActive(true);
      promptText.text = prompt;
      
   }
   
   public void HideActionPrompt()
   {
      actionPromptBox.SetActive(false);
      dialogReadyToPlay = false;
   }

   public void DisplayDialog()
   {
      indexOfSentenceToDisplay++;

      if (indexOfSentenceToDisplay >= nextDialogToShow.dialogSentences.Count)
      {
         dialogReadyToPlay = false;
         indexOfSentenceToDisplay = -1;
         GameManager.instance.EnablePlayerMovement();
         dialogBox.SetActive(false);
         SoundManager.instance.StopSfx();
         DialogCompleted?.Invoke();
      }
      else if (indexOfSentenceToDisplay == 0)
      {
         actionPromptBox.SetActive(false);
         GameManager.instance.DisablePlayerMovement();
      
         dialogBox.SetActive(true);
         dialogSpeaker.text = nextDialogToShow.dialogSentences[indexOfSentenceToDisplay].speakerName;
         dialogText.text = nextDialogToShow.dialogSentences[indexOfSentenceToDisplay].textToSay;
         string sfxToPlay = nextDialogToShow.dialogSentences[indexOfSentenceToDisplay].soundName;
         SoundManager.instance.PlayAudioClip(sfxToPlay);
      }
      else
      {
         dialogSpeaker.text = nextDialogToShow.dialogSentences[indexOfSentenceToDisplay].speakerName;
         dialogText.text = nextDialogToShow.dialogSentences[indexOfSentenceToDisplay].textToSay;
         string sfxToPlay = nextDialogToShow.dialogSentences[indexOfSentenceToDisplay].soundName;
         SoundManager.instance.PlayAudioClip(sfxToPlay);

      }
   }


   public bool DialogIsWaitingToPlay()
   {
      return dialogReadyToPlay;
   }

   public void SetupDialogQueue(Dialog dialog)
   {
      nextDialogToShow = dialog;
      dialogReadyToPlay = true;
      indexOfSentenceToDisplay = -1;
   }

}
