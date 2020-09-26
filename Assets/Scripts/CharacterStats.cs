using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public float maxHealth;
    public float health;
    public Transform healthBar;
    private float notReceivingDamage = 0;
    // Start is called before the first frame update
    void Start()
    {
        // At the beginning the health equals the maximum health
        health = maxHealth;
    }

    void Update()
    {
        // Once the character has not received damage during 3 seconds, his health recovers
        notReceivingDamage += Time.deltaTime;
        if ((health!=maxHealth) && (notReceivingDamage >= 3)) {
            health += Time.deltaTime * 6;
            health = Mathf.Min(health, maxHealth);
            healthBar.localScale = new Vector3(Mathf.Max(0, health/maxHealth), 1f, 1f);
        }
    }

    // Method for taking damage
    public void TakeDamage(int damage) {
        if (health > 0) {
            health -= damage;
            notReceivingDamage = 0;
            if (healthBar != null) {
                healthBar.localScale = new Vector3(Mathf.Max(0, health/maxHealth), 1f, 1f);
            }
            // If the health equals 0, the character dies
            if (health <= 0) {
                Die();
            }else{
                DamageSound();
            }
        }
        
    }

    public virtual void Die() {
        
    }

    public virtual void DamageSound() {

    }
}
