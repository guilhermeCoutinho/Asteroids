using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {

	Animator _animator;
	Animator animator {
		get {
			if (_animator == null)
				_animator = GetComponent<Animator>();
			return _animator;
		}
	}

	float timeToDestroySelf ;
	bool shouldDestroySelf;
	ObjectPool pool ;


	void Awake () {
		pool = GetComponentInParent<ObjectPool>();
	}

	public void Hit (Vector2 position) {
		transform.position = position;
		animator.SetTrigger("hit");
		timeToDestroySelf = Time.time + 1;
	}

	void Update () {
		if (shouldDestroySelf && Time.time > timeToDestroySelf)
			pool.returnObject(gameObject);
	}

}
