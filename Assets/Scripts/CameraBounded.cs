using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounded : MonoBehaviour {
	static bool alreadyCalculatedBounds = false;
	static Vector2 cameraBottomLeft ;
	static Vector2 cameraTopRight ;
    static Camera cam;
	static float halfCameraWidth;
	static float halfCameraHeigh;

	float xDistance;
	float yDistance;

	static void calculateCameraBounds () {
		if (alreadyCalculatedBounds) 
			return;
        alreadyCalculatedBounds = true;

		cam = Camera.main;
		Vector3 cameraCenter = cam.transform.position;
		halfCameraWidth = cam.orthographicSize * cam.aspect ;
		halfCameraHeigh = cam.orthographicSize ;
		
		cameraBottomLeft = new Vector2 (
			cameraCenter.x - halfCameraWidth,
			cameraCenter.y - halfCameraHeigh);
       
	    cameraTopRight = new Vector2(
	        cameraCenter.x + halfCameraWidth,
    	    cameraCenter.y + halfCameraHeigh);
	}

	void Awake () {
		calculateCameraBounds ();
	}

	void Update () {
		if (transform.position.x < cameraBottomLeft.x)
			transform.Translate (Vector3.right * halfCameraWidth * 2, Space.World);
		else if (transform.position.x > cameraTopRight.x)
            transform.Translate(Vector3.left * halfCameraWidth * 2, Space.World);
		if (transform.position.y < cameraBottomLeft.y)
			transform.Translate(Vector3.up * halfCameraHeigh * 2,Space.World);
		else if (transform.position.y > cameraTopRight.y)
            transform.Translate(Vector3.down * halfCameraHeigh * 2,Space.World);
	}
}
