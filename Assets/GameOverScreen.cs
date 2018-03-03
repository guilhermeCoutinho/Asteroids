using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class GameOverScreen : Singleton<GameOverScreen> {
    enum State
    {
        DORMENT,
        SETTING_UP,
        WAITING_PLAYER_INPUT,
        SHOWING_HIGH_SCORE
    }
	public GameObject firstPart;
	public GameObject secondPart;

	public Text playerNameTextField;
	public Button confirmNameButton;
	public int minNameLen;
	public int maxNameLen;
	string playerName ;

	State state ;
	Coroutine flashTextCursorCoroutine;
	bool showingCursor;

	void Start () {
		Activate();
	}

	public void Activate () {
		state = State.WAITING_PLAYER_INPUT;
		SetPlayerName ( playerName = "" );
        flashTextCursorCoroutine = StartCoroutine(flashTextCursor());
	}

	void Update () {
		switch (state)
		{
			case State.WAITING_PLAYER_INPUT:
				proccessPlayerInput();
				confirmNameButton.gameObject.SetActive(!nameIsTooShort());
			break;
		}
	}

	bool nameIsTooShort () {
		return playerName.Length < minNameLen;
	}

	void proccessPlayerInput () {
		if (Input.GetKeyDown(KeyCode.Return) && !nameIsTooShort() ) {
			state = State.SHOWING_HIGH_SCORE;
		}
		if (Input.GetKey(KeyCode.Backspace) && playerName.Length > 0) {
			SetPlayerName ( playerName.Remove (playerName.Length-1) );
		}
		if (playerName.Length >= maxNameLen)
			return;
        string input = Input.inputString;
		Regex rgx = new Regex("[^a-zA-Z0-9 -]");
		input = rgx.Replace(input, "");
		input.ToUpper();
		SetPlayerName (playerName + input );
	}



	void SetPlayerName (string newPlayerName) {
		playerName = newPlayerName;
        playerNameTextField.text = showingCursor ?
		playerName + "|" : playerName;
	}

	IEnumerator flashTextCursor () {
		while (state == State.WAITING_PLAYER_INPUT) {
			showingCursor = false;
            playerNameTextField.text = playerName;
            yield return new WaitForSeconds(.35f);
			showingCursor = true;
            playerNameTextField.text = playerName + "|";
            yield return new WaitForSeconds(.2f);
		}
	}
}
