using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BuyingController : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    public string conversationStartNode;

    public void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    public void StartConversation()
    {
        //isCurrentConvo = true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void EndConversation()
    {
        //isCurrentConvo = false;
    }

    // public void DisableConversation();
}
