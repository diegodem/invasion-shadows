using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            CharacterStats playerStats = other.gameObject.GetComponent<CharacterStats>();
            playerStats.TakeDamage(10);
        }
    }
}
