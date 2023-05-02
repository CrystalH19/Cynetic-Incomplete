using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Move : MonoBehaviour {
    public string sceneBuildIndex;
    public Color load = Color.black;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Player entered, so move level
            //SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            Initiate.Fade(sceneBuildIndex, load, 0.5f);
        }

    }

}
