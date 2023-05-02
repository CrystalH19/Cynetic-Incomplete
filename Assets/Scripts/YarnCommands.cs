using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using UnityEngine.UI;
using System.Security.Cryptography;
using Yarn;

public class YarnCommands : MonoBehaviour
{
    private GameObject dialogue;
    private DialogueRunner runner;

    [YarnCommand("goHome")]
    public static void move()
    {
        SceneManager.LoadScene("Home");
        Debug.Log("Go home");
    }

    [YarnCommand("disable")]
    public void disableDialogue(string dialogueBox)
    {
        dialogue = GameObject.Find(dialogueBox);
        dialogue.SetActive(false);
    }

    [YarnCommand("move")]
    public void sceneChange(string location)
    {
        Initiate.Fade(location, Color.black, 0.5f);
    }

    [YarnCommand("setsprite")]
    public void setSprite(string sprite, Image portrait)
    {
        portrait.enabled = true;
        portrait.sprite = Resources.Load<Sprite>(sprite);
        
    }

    [YarnCommand ("disableSprite")]
    public void disableSprite(Image portrait)
    {
        portrait.enabled = false;
    }

    [YarnCommand("checkWallet")]
    public int checkWallet()
    {

        IInventory inventory = GetComponent<IInventory>();
        if (inventory != null)
        {
            Debug.Log(inventory.Money);
            return inventory.Money;

        }
        else
        {
            Debug.Log(inventory.Money);
            return 0;
        }
    }

    
}
