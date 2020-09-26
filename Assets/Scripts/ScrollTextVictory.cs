using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollTextVictory : MonoBehaviour
{
    public float victoryTime;
    public float stopTime;
    public float totalTime;
    private float counter = 0;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // The text scrolls and then the Start scene is loaded again
        counter += Time.deltaTime;
        if (counter > victoryTime && counter < stopTime) {
            transform.Translate(new Vector3(0,90*Time.deltaTime,0));
        }else if (counter > stopTime) {
            audioSource.volume = Mathf.Lerp(1, 0, (counter-stopTime) / 8);
        }
        if (counter > totalTime) {
            SceneManager.LoadScene("StartScene");
        }

    }
}
