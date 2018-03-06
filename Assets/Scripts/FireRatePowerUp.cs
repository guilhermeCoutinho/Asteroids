using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour , IPowerUp{

	float timeToDie;

	PlayerWeapon fireWeaponBeingPoweredUp;
	float increaseFactor = 6;
	bool isActive = false;

	public void PowerUp (float duration) {
		timeToDie = Time.time + duration;
		isActive = true;
		fireWeaponBeingPoweredUp = GetComponent<PlayerWeapon>();
		fireWeaponBeingPoweredUp.ActivatePowerUp(increaseFactor);
	}

	public void Deactivate () {
		fireWeaponBeingPoweredUp.DeactivatePowerUp (increaseFactor);
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
