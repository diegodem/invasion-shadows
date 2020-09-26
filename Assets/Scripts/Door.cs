using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 destination;

    void OnTriggerEnter(Collider other)
    {
        // If the player collides with the door, his position changes to the destination
        other.transform.position = destination;
    }
}
