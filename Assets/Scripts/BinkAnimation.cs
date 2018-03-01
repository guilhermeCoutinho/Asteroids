using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinkAnimation : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	bool blink = false;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Blink () {
		blink = true;	
	}

	void Update () {
		if (blink){
			spriteRenderer.enabled = false;
			blink = false;
		}else if (spriteRenderer.enabled == false ){
			spriteRenderer.enabled = true;
		}
	}

}
