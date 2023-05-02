using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueStart : MonoBehaviour
{
    
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image portrait;
    [SerializeField] private String sprite;
    [SerializeField] private byte color1, color2, color3, color4;
    [SerializeField] private String textName;

    private TypeWriterEffect typewritereffect;
    private ResponseHandler responseHandler;
    [SerializeField] private DialogueSys rDialogue;
    [SerializeField] private GameObject dialoguebox;


    //Haku color is 241, 144, 144, 255
    private void Start()
    {
        portrait.sprite = Resources.Load<Sprite>(sprite);
        portrait.rectTransform.localScale = new Vector3(5, 5, 1);
        nameText.color = new Color32(color1, color2, color3, color4);
        nameText.text = textName;

        typewritereffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        showDialogue(rDialogue);
    }
    
    public void showDialogue(DialogueSys dialogueSys)
    {
        dialoguebox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueSys));
    }

    private IEnumerator StepThroughDialogue(DialogueSys dialogueSys)
    {
      /*  foreach (string dialogue in dialogueSys.Dialogue)
        {
            yield return typewritereffect.run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        } */

        for (int i = 0; i<dialogueSys.Dialogue.Length; i++)
        {
            string dialogue = dialogueSys.Dialogue[i];

            yield return typewritereffect.run(dialogue, textLabel);

            if (i == dialogueSys.Dialogue.Length - 1 && dialogueSys.HasResponses) break;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if (dialogueSys.HasResponses)
        {
            responseHandler.ShowReponses(dialogueSys.Responses);
        }
        else
        {
            closeBox();
        }
    }

    private void closeBox()
    {
        dialoguebox.SetActive(false);
        textLabel.text = string.Empty;

    }
}