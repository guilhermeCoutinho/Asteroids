using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGfx : MonoBehaviour {

	public GameObject shieldSprite;

	int activePowerUps = 0;

	public void Show (bool shouldShow) {
		if (shouldShow)
			activePowerUps ++;
		else 
			activePowerUps --;

		shieldSprite.SetActive(activePowerUps > 0);
	}

}
