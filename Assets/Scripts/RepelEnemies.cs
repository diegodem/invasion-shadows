using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelEnemies : MonoBehaviour
{

    Collider m_Collider;
    Vector3 m_Center;

    Collider e_Collider;
    Vector3 e_Center;
    private void OnTriggerEnter(Collider other)
    {
        // NOT IMPLEMENTED
        if (other.gameObject.tag == "Enemy") {
            Rigidbody enemyBody = other.gameObject.GetComponent<Rigidbody>();
            //Fetch the Collider from the GameObject
            m_Collider = GetComponent<Collider>();
            //Fetch the center of the Collider volume
            m_Center = m_Collider.bounds.center;

            e_Collider = other.gameObject.GetComponent<Collider>();
            e_Center = e_Collider.bounds.center;

            enemyBody.AddForce((Vector3.Normalize(e_Center - m_Center))*12,ForceMode.VelocityChange);
            //enemyBody.velocity = Vector3.Normalize(e_Center - m_Center)*8;
            
        }
    }
}
