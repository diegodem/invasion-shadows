using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class CheckButtonPress : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        // Chech if the start button has been pressed to change the scene
        if(CrossPlatformInputManager.GetButtonDown("Start")) {
            SceneManager.LoadScene("IntroScene");
        }
    }
}
