using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour , IPowerUp{

	float timeToDie;

	FireWeapon fireWeaponBeingPoweredUp;
	float increaseFactor = 3;
	bool isActive = false;

	public void PowerUp (float duration) {
		timeToDie = Time.time + duration;
		isActive = true;
		fireWeaponBeingPoweredUp = GetComponent<FireWeapon>();
		fireWeaponBeingPoweredUp.alternateFireMode = false;
		fireWeaponBeingPoweredUp.fireCooldown /= increaseFactor;
	}

	public void Deactivate () {
		fireWeaponBeingPoweredUp.alternateFireMode = true;
		fireWeaponBeingPoweredUp.fireCooldown *= increaseFactor;
		Destroy(this);
	}

	void Update () {
		if (!isActive)
			return;
		if (Time.time >= timeToDie) {
			Deactivate ();
		}
	}
}
