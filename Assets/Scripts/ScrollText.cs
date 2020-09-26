using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollText : MonoBehaviour
{
    public GameObject introText;
    public GameObject controlsText;
    public float scrollTime;
    public float totalTime;
    private float counter = 0;
    private IntroMusic introMusic;

    void Start() {
        controlsText.SetActive(false);
        introMusic = GameObject.FindGameObjectWithTag("Music").GetComponent<IntroMusic>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // The text scrolls and then the scene changes and the game begins
        introText.transform.Translate(new Vector3(0,95*Time.deltaTime,0));
        counter += Time.deltaTime;
        if (counter > scrollTime) {
            introText.SetActive(false);
            controlsText.SetActive(true);
            introMusic.lowerVolume(counter-scrollTime, totalTime-scrollTime);           

            if (counter > totalTime) {
                SceneManager.LoadScene("VillageScene");
                introMusic.StopMusic();
            }
        }

    }
}
