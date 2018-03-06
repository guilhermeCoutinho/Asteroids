using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , ILife {

	public int life = 4;
	public int pointsForDestroying = 1000;
    public float fireCooldown = 1;
    public int shotsPerRound = 2;
	public float roundInterval = .1f;
	public float errorMargin = 10;

    Transform playerTransform ;
	EnemyWeapon weapon;
	BinkAnimation blinkAnimation;

	void Awake () {
		playerTransform = Player.Instance.transform;
		weapon = GetComponent<EnemyWeapon>();
		blinkAnimation = GetComponent<BinkAnimation>();
	}

	void Start () {
		StartCoroutine(shoot());
	}

	IEnumerator shoot () {
		while (true) {
			yield return new WaitForSeconds (fireCooldown);
			for (int i = 0 ; i < shotsPerRound;i++){
				weapon.Shoot (getShotDirection());
				yield return new WaitForSeconds(roundInterval);
			}
		}
	}

	Vector2 getShotDirection () {
		float error = Random.Range (-errorMargin,errorMargin);
		error += errorMargin*Mathf.Sign(error);
        return Quaternion.Euler(0, 0 , error) * -transform.up;
	}

    public void TakeDamage(int qtd)
    {
        life -= qtd;
        if (life == 0)
        {
            Die();
        }
        else if (life > 0)
        {
            blinkAnimation.Blink();
        }
    }

    void Die()
    {
		Player.Instance.Score(pointsForDestroying);
		Destroy(gameObject);
    }
	
}
