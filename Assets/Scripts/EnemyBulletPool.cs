using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : ObjectPool {
	static EnemyBulletPool _instance;
	public static EnemyBulletPool instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<EnemyBulletPool>();
			}
			return _instance;
		}
	}

}
