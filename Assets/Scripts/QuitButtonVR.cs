using UnityEngine;
using System.Collections; // Required for IEnumerator
using UnityEngine.SceneManagement; // Correct namespace for SceneManager
using UnityEngine.UI;
/*
 * 1. For every ButtonUI I created, I created a separate GameObject, Attached the QuitButtonVR.cs 
 * script to the GameObject and then for the ButtonUI->OnClick() dragged the GameObject over, then from the 
 * dropdown selected the associated method ex. ShowQuitButton or Start
 * 
 * 2. Ex - The ButtonUI is called Timer which is the button to qui
 * t and Gameobject for this is ForTimer.
 * 3. Timer  display countdown) is called ShowCoundown (Text UI) The game obecjt for that is 
 * ForTimer too. 
 * 
 * NOTE - did not test it on cardboard ( camera may be way off) 
 * 
 * */
 
public class QuitButtonVR : MonoBehaviour
{
    public Button quitButton; // Assign this in the inspector
    public Text countdownText; //to display counter

    void Start()
    {

        quitButton.gameObject.SetActive(false);//hide the button
        countdownText.gameObject.SetActive(true);// Show the timer
        StartCoroutine(ShowQuitButtonAfterTime(10)); // Start the countdown
    }
    void Update()
    {
        // Check if the Google Cardboard trigger is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            QuitApplication();
        }
    }
    IEnumerator ShowQuitButtonAfterTime(float time)
    {

        // yield return new WaitForSeconds(time); // Wait for the specified time
        while (time > 0) // Loop to count down
        {
            countdownText.text = "Countdown: " + time; // for the countdown to be displayed. 
            Debug.Log("Countdown: " + time); // Log the countdown time
            yield return new WaitForSeconds(1f); // Wait for one second
            time--; // Decrement the time
        }
        countdownText.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true); // Show the quit button
    }

    // You can add this method to the button's OnClick() event in the inspector
    public void QuitApplication()
    {

#if UNITY_EDITOR
        Debug.Log("yOU ARE DEAD");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("yOU ARE DEAD");
        Application.Quit(); // Quit the application
     
#endif
    }
}

