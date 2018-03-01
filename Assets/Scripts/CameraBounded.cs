using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounded : MonoBehaviour {

	float xDistance;
	float yDistance;

	void Awake () {
		CameraBounds.CalculateCameraBounds();
	}

	void Update () {
		if (transform.position.x < CameraBounds.BottomLeft.x)
			transform.Translate (Vector3.right * CameraBounds.HalfWidth * 2, Space.World);
		else if (transform.position.x > CameraBounds.TopRight.x)
            transform.Translate(Vector3.left * CameraBounds.HalfWidth * 2, Space.World);
		if (transform.position.y < CameraBounds.BottomLeft.y)
			transform.Translate(Vector3.up * CameraBounds.HalfHeigh * 2,Space.World);
		else if (transform.position.y > CameraBounds.TopRight.y)
            transform.Translate(Vector3.down * CameraBounds.HalfHeigh * 2,Space.World);
	}
}
