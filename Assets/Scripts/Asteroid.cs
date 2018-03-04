using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour , ILife {
	public enum Size {
        LARGE, MEDIUM, SMALL
    }
	float life;
	Rigidbody2D rb;
	SpriteRenderer spriteRenderer;
    BinkAnimation blinkAnimation;
	Size size;
	ObjectPool pool;
	BoxCollider2D col;
	AsteroidData data;
	
	UnityAction<Size,Vector2> onAsteroidDied;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		blinkAnimation = GetComponent<BinkAnimation>();
		rb = GetComponent<Rigidbody2D>();
		pool = GetComponentInParent<ObjectPool>();
        col = GetComponent<BoxCollider2D>();
	}

	public void Setup ( AsteroidData data , Size size , UnityAction<Size,Vector2> onAsteroidDied) {
		spriteRenderer.sprite = data.sprites[Random.Range(0,data.sprites.Length)];
		this.data = data;
		recalculateCollider ();
		rb.mass = data.mass;
		this.life = data.life;
		this.size = size;
		this.onAsteroidDied = onAsteroidDied ;
	}

	public void MoveInDirection (Vector3 direction , float force) {
		rb.AddForce (direction.normalized * force ,ForceMode2D.Impulse);
	}

	public void RotateInDirection (float torque) {
		rb.AddTorque (torque,ForceMode2D.Impulse);
	}

	public void TakeDamage (int qtd) {
		life -= qtd;
		if (life == 0) {
			Die ();
		}else if (life > 0) {
			blinkAnimation.Blink ();
		}
	}

	void Die () {
		if (data != null)
			Player.Instance.Score (data.pointsForDestroying);
		rb.velocity = Vector2.zero;
		rb.rotation = 0;
		if (onAsteroidDied != null)
	        onAsteroidDied(size,transform.position);
		pool.returnObject (gameObject);
	}

	void recalculateCollider () {
        Vector2 S = spriteRenderer.sprite.bounds.size;
        col.size = S;
        col.offset = Vector2.zero;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag.Equals("Player")) {
			col.gameObject.GetComponent<ILife>().TakeDamage(1);
		}
	}
}
