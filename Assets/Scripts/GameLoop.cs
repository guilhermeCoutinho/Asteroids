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
			if (allAsteroidsAreDead()){
				asteroidSpawner.RandomSpawnAsteroid (spawnAmount);
				spawnAmount += asteroidIncreasePerLevel;
			}
		}
	}

	bool isPlayerDead () {
		return Player.Instance.life <= 0;
	}

	bool allAsteroidsAreDead () {
		return asteroidPool.getActiveObjectCount () == 0;
	}
}
