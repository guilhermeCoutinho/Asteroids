using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {
    static bool alreadyCalculatedBounds = false;
    static Camera cam;
    static float halfCameraWidth;
    static float halfCameraHeigh;
    static Vector2 cameraBottomLeft;
    static Vector2 cameraTopRight;

	public static Vector2 BottomLeft {
		get {
			return cameraBottomLeft;
		}
	}

    public static Vector2 TopRight
    {
        get
        {
            return cameraTopRight;
        }
    }

	public static float HalfWidth {
		get {
			return halfCameraWidth;
		}
	}
	public static float HalfHeigh {
		get {
			return halfCameraHeigh;
		}
	}

    public static void CalculateCameraBounds()
    {
        if (alreadyCalculatedBounds)
            return;
        alreadyCalculatedBounds = true;

        cam = Camera.main;
        Vector3 cameraCenter = cam.transform.position;
        halfCameraWidth = cam.orthographicSize * cam.aspect;
        halfCameraHeigh = cam.orthographicSize;

        cameraBottomLeft = new Vector2(
            cameraCenter.x - halfCameraWidth,
            cameraCenter.y - halfCameraHeigh);

        cameraTopRight = new Vector2(
            cameraCenter.x + halfCameraWidth,
            cameraCenter.y + halfCameraHeigh);
    }

	public static Vector2 getRandomPointInsideBounds (float minimumDistanceFromBounds) {
		float randomX = Random.Range (BottomLeft.x + minimumDistanceFromBounds,
			TopRight.x - minimumDistanceFromBounds);
        float randomY = Random.Range(BottomLeft.x + minimumDistanceFromBounds,
        	TopRight.x - minimumDistanceFromBounds);
		return new Vector2 (randomX,randomY);
	}

}
