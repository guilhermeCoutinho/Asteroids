using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour {
	
	Animator animator;
	float worldHeight ;
	
	void Start () {
		worldHeight = Camera.main.orthographicSize * .5f;
		animator = GetComponent<Animator>();
	}

	void Update () {
		animator.SetBool(Animator.StringToHash("show"),
			Player.Instance.transform.position.y < worldHeight);
	}
}
