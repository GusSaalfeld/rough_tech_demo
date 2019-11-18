using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public void TriggerDialogue()
    {
      //Have this be the whole start
      print("starting dialogue");
      FindObjectOfType<DialogueManager>().StartDialogue(); //part after . is a function call
    }
}
