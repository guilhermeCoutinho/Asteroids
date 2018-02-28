using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {
	public float driveForce;
	[Range(0,1)]
	public float slowingFactor = .9f;
	public float rotateSpeed;
	float currentSpeed;
    Rigidbody2D rb;
    PlayerInput pInput;

	void Awake () {
		rb= GetComponent<Rigidbody2D> ();
		pInput = GetComponent<PlayerInput>();
	}

	void FixedUpdate( ) {
		applyTrhust ();
		applyRotation();
	}

	void applyRotation () {
		transform.Rotate (Vector3.back * pInput.Rotation * rotateSpeed );
	}

	void applyTrhust () {
		rb.velocity *= slowingFactor;
		if (pInput.Thrust > 0) {
			currentSpeed = rb.velocity.magnitude;
			float propulsion = driveForce * pInput.Thrust - (Mathf.Clamp(currentSpeed, 0f, driveForce));
			rb.AddForce(propulsion * transform.up, ForceMode2D.Force);
		}
	}
}
