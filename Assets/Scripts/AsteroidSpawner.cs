using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AsteroidFactory))]
public class AsteroidSpawner : MonoBehaviour {

	AsteroidFactory asteroidFactory;
	public float minimumDistanceFromBorders;
	public float minimumAsteroidSpawnVelocity = 2;
    public float maxAsteroidSpawnVelocity = 4;


	void Awake () {
		asteroidFactory = GetComponent<AsteroidFactory>();
	}

	public void RandomSpawnAsteroid (int qtd) {
		for (int i=0;i<qtd;i++)
			SpawnAsteroid (CameraBounds.getRandomPointInsideBounds
				(minimumDistanceFromBorders),Asteroid.Size.LARGE);
	}

    public void RandomSpawnAsteroid(int qtd , Vector2 centerPosition , Asteroid.Size size)
    {
        for (int i = 0; i < qtd; i++){
			SpawnAsteroid  ( centerPosition + Random.insideUnitCircle.normalized , size);
		}
    }

	public void SpawnAsteroid (Vector2 position , Asteroid.Size size){
        Asteroid asteroid = asteroidFactory.CreateAsteroid(size,OnAsteroidDied);
        asteroid.transform.position = position;
        asteroid.MoveInDirection(Random.insideUnitCircle,
            Random.Range(minimumAsteroidSpawnVelocity, maxAsteroidSpawnVelocity));
        float randomRotation = Random.Range(-1, 1);
        randomRotation += Mathf.Sign(randomRotation);
        asteroid.RotateInDirection(randomRotation);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			RandomSpawnAsteroid (5);
		}
	}

	public void OnAsteroidDied (Asteroid.Size size, Vector2 position) {
		if (size == Asteroid.Size.LARGE)
			RandomSpawnAsteroid(2,position,Asteroid.Size.MEDIUM);
        if (size == Asteroid.Size.MEDIUM)
            RandomSpawnAsteroid(4, position, Asteroid.Size.SMALL);
	}
}
