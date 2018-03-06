using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public enum EnemyType {
		EASY,MEDIUM,HARD
	}

	public GameObject easyEnemy;
	public GameObject mediumEnemy;
	public GameObject hardEnemy;

	public void Spawn (EnemyType type) {
		Vector2 position = CameraBounds.getRandomPointInsideBounds(0,4);
		switch (type)
		{
			case EnemyType.EASY:
				Instantiate(easyEnemy, position,Quaternion.identity,transform);
			break;
            case EnemyType.MEDIUM:
                Instantiate(mediumEnemy, position, Quaternion.identity, transform);
                break;
            case EnemyType.HARD:
                Instantiate(hardEnemy, position, Quaternion.identity, transform);
                break;
		}
	}
}
