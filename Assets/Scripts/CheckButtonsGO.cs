using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class CheckButtonsGO : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        // Check if the buttons have been pressed to change the scene
        if(CrossPlatformInputManager.GetButtonDown("Start")) {
            SceneManager.LoadScene("VillageScene");
        }else if (CrossPlatformInputManager.GetButtonDown("Cancel")) {
            SceneManager.LoadScene("StartScene");
        }
    }
}
