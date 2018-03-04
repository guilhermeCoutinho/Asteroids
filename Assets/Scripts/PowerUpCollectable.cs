using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectable : MonoBehaviour , ICollectable {
	public enum Type {
		IMMUNITY,
		POWER,
		HEALTH
	}
	public float duration;
	public Type type;

	void OnTriggerEnter2D (Collider2D col) 
	{
		if (GameLoop.state != GameLoop.GameState.RUNNING)
			return;
		bool showUIndicator = true;
		switch (type)
		{
			case Type.IMMUNITY:
            	Player.Instance.gameObject.AddComponent<ShieldPowerUp>().PowerUp(duration);
			break;
			case Type.POWER:
				Player.Instance.gameObject.AddComponent<FireRatePowerUp>().PowerUp(duration);
			break;
            case Type.HEALTH:
				showUIndicator = false;
            	Player.Instance.GetLifeUp();
            break;
		}
		if (showUIndicator)
	        GetComponentInParent<PowerUpUI>().StartPowerUp(duration, GetComponent<SpriteRenderer>().sprite);
		Destroy(gameObject);
	}
}
