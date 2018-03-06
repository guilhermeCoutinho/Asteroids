using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerTeleporter : MonoBehaviour {

	PlayerInput input;

	void Awake () {
		input = GetComponent<PlayerInput>();
	}

	void Update () {
		if (input.TeleportButtonPressed) {
			transform.position = CameraBounds.getRandomPointInsideBounds(2,0);
		}
	}
}
