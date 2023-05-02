using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueSys dialogueObject;

    public string ResponseText => responseText;

    public DialogueSys DialogueSys => DialogueSys;
}
