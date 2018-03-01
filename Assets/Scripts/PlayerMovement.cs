using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {
	public float driveForce;
	public float maxSpeed;
	[Range(0,1)]
	public float slowingFactor = .9f;
	public float rotateSpeed;
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
			float propulsion = driveForce * pInput.Thrust;
			rb.AddForce(propulsion * transform.up, ForceMode2D.Force);
		}
		clampVelocity () ;
	}

	void clampVelocity () {
		var v = rb.velocity;
        if (v.magnitude > maxSpeed)
            rb.velocity = v.normalized * maxSpeed;
	}
}
