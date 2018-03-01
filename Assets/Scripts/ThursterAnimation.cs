using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class ThursterAnimation : MonoBehaviour {
	PlayerInput playerInput;

	public SpriteRenderer LeftThurster;
	public SpriteRenderer RightThruster;
	public SpriteRenderer CenterThuster;

	void Awake () {
		playerInput = GetComponent<PlayerInput>();
	}
	
	void Update () {
		CenterThuster.enabled = playerInput.Thrust > 0;
        LeftThurster.enabled = playerInput.Rotation > 0;
        RightThruster.enabled = playerInput.Rotation < 0;
	}
}
