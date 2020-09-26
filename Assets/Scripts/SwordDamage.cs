using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // When the attack collides with an enemy, it receives damage
        if (other.gameObject.tag == "Enemy") {
            CharacterStats enemyStats = other.gameObject.GetComponent<CharacterStats>();
            enemyStats.TakeDamage(20);
        }
    }
}
