using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float timeToLive;
	Rigidbody2D rb;
	bool isAlive = false;
	ObjectPool pool ;
	float deathTime;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		pool =GetComponentInParent<ObjectPool>();
	}

	public void Fire (Vector2 origin , Vector2 direction, float Force) {
		transform.position = origin;
		transform.Rotate (0,0,Vector2.SignedAngle(transform.up,direction));
		rb.AddForce (direction.normalized * Force , ForceMode2D.Impulse);
		isAlive = true;
		deathTime = Time.time + timeToLive;
	}

	void Disable () {
		rb.velocity = Vector3.zero;
		isAlive = false;
	}

	void Update () {
		if (isAlive && Time.time > deathTime)
			pool.returnObject(gameObject);
	}

	void OnTriggerEnter2D (Collider2D col) {
		ILife life = col.GetComponent<ILife>();
		if (life != null){
			life.TakeDamage (1);
			Debug.Log ("Pool is null " +  pool == null );
            Debug.Log( "GO is null " + gameObject == null);

            pool.returnObject(gameObject);
		}
	}
}
