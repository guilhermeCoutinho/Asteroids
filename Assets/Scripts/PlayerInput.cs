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
    bool teleportButtonPressed;
    public bool TeleportButtonPressed
    {
        get
        {
            return teleportButtonPressed;
        }
    }

	void Update () {
		if (GameLoop.state != GameLoop.GameState.RUNNING){
			thrust = rotation = 0;
			fireButtonPressed = false;
			teleportButtonPressed = false;
			return;
		}
		thrust =  Mathf.Clamp01 ( Input.GetAxisRaw("Vertical") );
		rotation = Input.GetAxisRaw("Horizontal");
		fireButtonPressed = Input.GetButton("Fire1");
		teleportButtonPressed = Input.GetButtonDown("Jump");
	}
}
