using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusic : MonoBehaviour
{
    private AudioSource _audioSource;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }

     public void lowerVolume(float currentTime, float totalTime) {
         _audioSource.volume = Mathf.Lerp(1, 0, currentTime / totalTime);
     }
}
