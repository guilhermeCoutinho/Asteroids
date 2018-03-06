using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerWeapon : MonoBehaviour {

    public float projectileForce;
	public float fireCooldown;

	public ObjectPool playerBulletPool;
	public Transform[] Cannons;

	public int activePowerUps = 0;
	public float fireRateModifier  = 1 ;
	int canonToFire = 0;
	PlayerInput playerInput;
	float readyToFireAgainTime = -1;

	void Awake () {
		playerInput = GetComponent<PlayerInput>();
	}

	public void ActivatePowerUp (float modifier) {
		activePowerUps ++;
		fireRateModifier /= modifier;
	}

	public void DeactivatePowerUp (float modifier) {
		activePowerUps --;
		fireRateModifier *= modifier;
	}

	void Update () {
		if (!canFireAgain())
			return;

		if (playerInput.FirebuttonPressed){
			if (activePowerUps > 0) {
				fire (Cannons[canonToFire]);
				canonToFire = (canonToFire + 1) % Cannons.Length;
			}else{
				foreach (Transform t in Cannons)
					fire(t);
			}
			readyToFireAgainTime = Time.time + fireCooldown * fireRateModifier;
			AudioManager.PlayOneShot(AudioManager.Instance.playerShoots);
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
