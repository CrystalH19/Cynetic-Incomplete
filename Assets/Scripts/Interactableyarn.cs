using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class Interactableyarn : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    
    public KeyCode interactKey;
    private bool interactable;
    public bool inRange;
    //private bool isCurrentConvo;
     public UnityEvent interactAction;
    

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("Exit");
        }
    }

    
}
