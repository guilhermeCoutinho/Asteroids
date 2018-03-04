using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour {

	public GameObject prefabPower ;
	public GameObject prefabShield;
	public GameObject healthUp;
	
	public void SpawnPowerUp (PowerUpCollectable.Type type) {
		switch (type)
		{
			case PowerUpCollectable.Type.POWER:
				Instantiate(prefabPower,
				CameraBounds.getRandomPointInsideBounds(2,2),
				Quaternion.identity,transform);
			break;
			case PowerUpCollectable.Type.IMMUNITY:
                Instantiate(prefabShield,
                    CameraBounds.getRandomPointInsideBounds(2, 2),
                    Quaternion.identity, transform);
			break;
            case PowerUpCollectable.Type.HEALTH:
                Instantiate(healthUp,
                    CameraBounds.getRandomPointInsideBounds(2, 2),
                    Quaternion.identity, transform);
                break;
		}
	}


    public void RandomSpawnPowerups(int qtd)
    {
		for (int i=0;i<qtd;i++){
			float random = Random.Range(0f,1f);
			if (random <= .33f)
				SpawnPowerUp(PowerUpCollectable.Type.IMMUNITY);
			else if (random <= .66f)
                SpawnPowerUp(PowerUpCollectable.Type.POWER);
			else
                SpawnPowerUp(PowerUpCollectable.Type.HEALTH);
		}
    }
}
