using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinkAnimation : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	bool blink = false;

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
