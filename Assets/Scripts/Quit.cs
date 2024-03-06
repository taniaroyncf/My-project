
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Correct namespace for SceneManager
using UnityEngine.UI;

/* Intial test file the final one is called QuitButtonVR.cs*/

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartgame()
    {
        Debug.Log("Restarted Again");
        SceneManager.LoadScene("SampleScene");
       Debug.Log("Restarted Again");
    }

    // Update is called once per frame
    public void exit()
    {
        // Note: UnityEditor.EditorApplication.isPlaying will only work in the Unity Editor.
        // It's a good practice to wrap it in a preprocessor directive to avoid errors in a build.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("BYe");
        Application.Quit();
        Debug.Log("BYe");

#endif
    }
}
