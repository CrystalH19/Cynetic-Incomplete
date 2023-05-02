using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundClick : MonoBehaviour
{
    public AudioSource sound;
    public Button button;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (sound == null)
        {
            Debug.Log("null");
        }
        else
            sound.Play();
    }
}
