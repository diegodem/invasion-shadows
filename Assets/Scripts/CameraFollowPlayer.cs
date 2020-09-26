using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 cameraOffset;
    void Start() {
        // The offset between the camera and the player is fixed 
        cameraOffset = transform.position - playerTransform.position;

    }
    void FixedUpdate()
    {
        // Every time the player moves, the camera moves too
        transform.position = playerTransform.position + cameraOffset;
    }
}
