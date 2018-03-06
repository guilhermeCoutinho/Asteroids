using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {
	public enum GameState  {
		RUNNING, 
		PAUSED
	}

	public static GameState state;

	public ObjectPool asteroidPool;
	public AsteroidSpawner asteroidSpawner ;
	public GameOverScreen gameOverScreen;
	public CollectableSpawner collectableSpawner;
	public EnemySpawner enemySpawner;

	public int spawnAmount = 1;
	public int asteroidIncreasePerLevel = 2;

	public void Start () {
		state = GameState.RUNNING;
	}

	public void PauseGame () {
		state = GameState.PAUSED;
	}

	public void RestartGame () {
	}

	void Update () {
		if (state == GameState.RUNNING) {
            if (isPlayerDead())
            {
                state = GameState.PAUSED;
				gameOverScreen.Activate();
            }
			if (levelEnded()){
				asteroidSpawner.RandomSpawnAsteroid (spawnAmount);
                collectableSpawner.RandomSpawnPowerups((int)Mathf.Log(spawnAmount,2));
                SpawnEnemies();
				spawnAmount += asteroidIncreasePerLevel;
			}
		}
	}

	void SpawnEnemies () {
		if (spawnAmount == 1) {
            enemySpawner.Spawn(EnemySpawner.EnemyType.EASY);
			return;
		}if (spawnAmount == 2)
        {
            enemySpawner.Spawn(EnemySpawner.EnemyType.HARD);
            return;
        }if (spawnAmount == 3)
        {
            enemySpawner.Spawn(EnemySpawner.EnemyType.MEDIUM);
            return;
        }


        for (int i = 0 ; i < Mathf.Log(spawnAmount,2);i++){
			if (coinToss())
				enemySpawner.Spawn(EnemySpawner.EnemyType.EASY);
			else if (coinToss())
                enemySpawner.Spawn(EnemySpawner.EnemyType.MEDIUM);
			else
                enemySpawner.Spawn(EnemySpawner.EnemyType.HARD);
		}
	}

	bool coinToss () {
		return Random.Range(0f,1f) < .5f;
	}

	bool isPlayerDead () {
		return Player.Instance.life <= 0;
	}

	bool levelEnded () {
		return asteroidPool.getActiveObjectCount () == 0 && 
			enemySpawner.transform.childCount == 0;
	}
}
