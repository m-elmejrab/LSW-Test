using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : ActionPromptTrigger
{
   private Dialog dialogToShow;

   private void Start()
   {
      dialogToShow = GetComponent<Dialog>();
   }

   protected override void OnTriggerEnter2D(Collider2D col)
   {
      base.OnTriggerEnter2D(col);
      DialogSystem.instance.SetupDialogQueue(dialogToShow);
   }

   protected override void OnTriggerExit2D(Collider2D other)
   {
      base.OnTriggerExit2D(other);
   }
}
