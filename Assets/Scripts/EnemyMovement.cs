using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	Transform playerTransform;
    public bool isChaser = true;
	public float driveForce = 3;
    public float maxSpeed = 3;
    public float maxTurningSpeed = 3;
	public float distanceToChasePlayer = 5;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		playerTransform = Player.Instance.transform;
    }

    void FixedUpdate()
    {
        if (isChaser)
            applyTrhustChaser();
        else 
            applyTrhustAfraidOfPlayer ();
        applyRotation();
    }

    void applyRotation()
    {
        float rotationAngle = Vector2.SignedAngle(transform.up, transform.position - playerTransform.position);
        float sign = Mathf.Sign(rotationAngle);
        rotationAngle = Mathf.Min (Mathf.Abs(rotationAngle),maxTurningSpeed);
        rotationAngle *= sign;
        transform.Rotate(0, 0,rotationAngle);
    }

    void applyTrhustChaser ()
    {
		if (chasePlayer())
			rb.AddForce(driveForce * -transform.up, ForceMode2D.Force);
		else
            rb.AddForce(driveForce * transform.up, ForceMode2D.Force);
        clampVelocity();
    }

    void applyTrhustAfraidOfPlayer()
    {
		rb.AddForce(driveForce * transform.up, ForceMode2D.Force);
        clampVelocity();
    }

    void clampVelocity()
    {
        var v = rb.velocity;
        if (v.magnitude > maxSpeed)
            rb.velocity = v.normalized * maxSpeed;
    }

	bool chasePlayer () {
		return distanceFromPlayer() > distanceToChasePlayer;
	}

	float distanceFromPlayer () {
		return Vector2.Distance(transform.position, playerTransform.position);
	}
}
