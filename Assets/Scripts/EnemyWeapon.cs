using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour, IWeapon {

	public Transform[] cannons;
	public float projectileForce;
	public bool alternateFireMode;
	int cannonToShoot = 0;

	public void Shoot (Vector2 direction){
		if (alternateFireMode) {
			Bullet bullet = EnemyBulletPool.instance.getObject().GetComponent<Bullet>();
			bullet.Fire(cannons[cannonToShoot].position, direction, projectileForce);
            cannonToShoot = (cannonToShoot + 1) % cannons.Length;
		}else {
			for (int i=0;i<cannons.Length;i++) {
                Bullet bullet = EnemyBulletPool.instance.getObject().GetComponent<Bullet>();
                bullet.Fire(cannons[i].position, direction, projectileForce);
			}
		}
	}
}
