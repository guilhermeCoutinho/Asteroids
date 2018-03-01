using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidFactory : MonoBehaviour {
	
	public ObjectPool asteroidPool;
	public AsteroidData large;
	public AsteroidData medium;
	public AsteroidData small;

	public Asteroid CreateAsteroid (Asteroid.Size size , UnityAction<Asteroid.Size,Vector2> onAsteroidDied) {
		Asteroid asteroid = asteroidPool.getObject().GetComponent<Asteroid>();
		switch (size)
		{
			case Asteroid.Size.SMALL:
				asteroid.Setup(small , size , onAsteroidDied);
				break;
			case Asteroid.Size.MEDIUM:
                asteroid.Setup(medium, size, onAsteroidDied);
				break;
			case Asteroid.Size.LARGE:
                asteroid.Setup(large, size, onAsteroidDied);
				break;
		}
		return asteroid;
	}
}
