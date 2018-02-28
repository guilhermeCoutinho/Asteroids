using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class FireWeapon : MonoBehaviour {

    public float projectileForce;
	public float fireCooldown;

	public ObjectPool playerBulletPool;
	public Transform[] Cannons;

	public bool alternateFireMode = false;
	int canonToFire = 0;
	PlayerInput playerInput;
	float readyToFireAgainTime = -1;

	void Awake () {
		playerInput = GetComponent<PlayerInput>();
	}

	public void ActivatePowerUp (float powerUpDuration) {
		alternateFireMode = false;
	}

	void Update () {
		if (!canFireAgain())
			return;

		if (playerInput.FirebuttonPressed){
			if (alternateFireMode) {
				fire (Cannons[canonToFire]);
				canonToFire = (canonToFire + 1) % Cannons.Length;
			}else{
				foreach (Transform t in Cannons)
					fire(t);
			}

			readyToFireAgainTime = Time.time + fireCooldown;
		}
	}

	void fire (Transform cannon) {
		Bullet bullet = playerBulletPool.getObject().GetComponent<Bullet>();
        bullet.Fire(cannon.position, transform.up, projectileForce);
	}

	bool canFireAgain () {
		return Time.time >= readyToFireAgainTime;
	}
}
