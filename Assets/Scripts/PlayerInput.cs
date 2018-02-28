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
	bool fireButtonPressed;
	public bool FirebuttonPressed {
		get { 
			return fireButtonPressed;
		}
	}

	void Update () {
		thrust =  Mathf.Clamp01 ( Input.GetAxis("Vertical") );
		rotation = Input.GetAxis("Horizontal");
		fireButtonPressed = Input.GetButton("Fire1");
	}
}
