using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform objectToFollow;

    [SerializeField]
    float cameraFollowSpeed = 5;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    float zOffset = -10;
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPosition = new Vector3(objectToFollow.position.x + xOffset,
            objectToFollow.position.y + yOffset, zOffset);

        transform.position = 
            Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime); 
	}
}
