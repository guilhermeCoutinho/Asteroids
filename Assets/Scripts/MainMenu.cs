using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public AsteroidSpawner spawner ;

	public int astroidsToSpawn = 10;

	IEnumerator Start () {
		for (int i = 0 ;i<astroidsToSpawn;i++){
			Spawn(Asteroid.Size.SMALL);
            yield return null;
            Spawn(Asteroid.Size.MEDIUM);
            yield return null;
            Spawn(Asteroid.Size.LARGE);
			yield return null;
		}
	}
	void Spawn (Asteroid.Size size) {
		spawner.SpawnAsteroid(
			CameraBounds.getRandomPointInsideBounds(0),
			size);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			StartGame();
	}

	public void StartGame () {
		SceneManager.LoadScene("main_game");
	}
}
