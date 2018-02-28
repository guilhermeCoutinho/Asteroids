using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	float thrust;
	public float Thrust {
		get {
			return thrust;
		}
	}
	float rotation;
	public float Rotation {
		get {
			return rotation ;
		}
	}

	void Update () {
		thrust =  Mathf.Clamp01 ( Input.GetAxis("Vertical") );
		rotation = Input.GetAxis("Horizontal");
	}
}
