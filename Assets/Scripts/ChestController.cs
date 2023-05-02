using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChestController : MonoBehaviour
{
    public Animator animator;
    public bool isOpen;

    public int cashValue = 1;
    public int potionValue = 1;
    private DialogueRunner dialogueRunner;
    public string notification;

    public void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }
    public void StartConversation()
    {
        //isCurrentConvo = true;
        dialogueRunner.StartDialogue(notification);
    }

    public void OpenChest()
    {
        animator = GetComponent<Animator>();

        if (isOpen == false)
        {
            isOpen = true;
            Debug.Log("Chest opened");
            animator.SetBool("isOpen", true);
            StartConversation();
            
        }
        else
        {
            animator.SetBool("isOpen", false);
        }
    }

    public void getMoney(Collider2D other)
    {
        IInventory inventory = other.GetComponent<IInventory>();
        if (other.tag == "Player")
        {
            if (inventory != null)
            {
                inventory.Money = inventory.Money + cashValue;
                Debug.Log("Player inventory has " + inventory.Money + " money in it.");
                
            }
        }
    }

    public void getPotion(Collider2D other)
    {
        IInventory inventory = other.GetComponent<IInventory>();
        if (other.tag == "Player")
        {
            if (inventory != null)
            {
                inventory.Potion = inventory.Potion + potionValue;
                Debug.Log("Player inventory has " + inventory.Potion + " potions in it.");
            }
        }
    }

}