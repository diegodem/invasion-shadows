using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    private AudioSource music;

    AudioSource[] sounds;
    void Start() {
        health = maxHealth;
        sounds = GetComponents<AudioSource>();
        music = GameObject.FindGameObjectWithTag("OverworldMusic").GetComponent<AudioSource>();
    }
    // When the player dies, the game over scene is loaded
    public override void Die() {
        music.Stop();
        sounds[2].Play();
        Time.timeScale = 0.05f;
        Invoke("ChangeScene",0.1f);
    }

    public override void DamageSound(){
        sounds[1].Play();
    }

    void ChangeScene() {
        SceneManager.LoadScene("GameOverScene");
        Time.timeScale = 1f;
    }
}
