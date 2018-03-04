using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGfx : MonoBehaviour {

	public GameObject shieldSprite;


	public void Show (bool shouldShow) {
		shieldSprite.SetActive(shouldShow);
	}

}
