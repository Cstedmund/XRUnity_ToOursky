using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDemoNPC : NPC
{
    protected override void OnEnable() {
        //base.OnEnable();
    }

    protected override void OnDialogueFinshed() {
        dialogueStateComplete = true;
    }
}
