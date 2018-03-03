using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {

	Player player;
	public Text lifeText;
    public Text scoreText;

	void Awake () {
		player = GetComponent<Player>();
	}

	void Update () {
		updateLife ();
		updateScore();
	}

    void updateLife()
    {
        lifeText.text = "x" + player.life;
    }


    void updateScore()
    {
        scoreText.text = player.GetPlayerScore().ToString().PadLeft(10, '0');
    }
}
