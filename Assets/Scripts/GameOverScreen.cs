using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

	CanvasGroup canvasGroup;
	string playerName ;

	State state ;
	Coroutine flashTextCursorCoroutine;
	bool showingCursor;

	public void Activate () {
		gameObject.SetActive (true);
        canvasGroup = GetComponent<CanvasGroup>();
		state = State.SETTING_UP;
		firstPart.SetActive(true);
		secondPart.SetActive(false);
		SetPlayerName ( playerName = "" );
		if (flashTextCursorCoroutine!=null)
			StopCoroutine(flashTextCursorCoroutine);
        flashTextCursorCoroutine = StartCoroutine(flashTextCursor());
		confirmNameButton.gameObject.SetActive(false);
		canvasGroup.alpha = 0;
	}

	public void GoToMenu () {
		SceneManager.LoadScene("main_menu");
	}

	void Update () {
		switch (state)
		{
			case State.SETTING_UP: 
				FadeIn ();
			break;
			case State.WAITING_PLAYER_INPUT:
				proccessPlayerInput();
				confirmNameButton.gameObject.SetActive(!nameIsTooShort());
			break;
			case State.SHOWING_HIGH_SCORE:
			if (Input.GetKeyDown(KeyCode.Return))
				GoToMenu();
			break;
		}
	}

	void FadeIn () {
        canvasGroup.alpha += Time.deltaTime;
        if (canvasGroup.alpha >= 1){
            canvasGroup.alpha = 1;
			state = State.WAITING_PLAYER_INPUT;
		}
	}

	public void confirmName () {
        state = State.SHOWING_HIGH_SCORE;
		firstPart.SetActive(false);
		secondPart.SetActive(true);
		secondPart.GetComponent<HighScore>().ShowHighScores(playerName,
			Player.Instance.GetPlayerScore());
	}

	bool nameIsTooShort () {
		return playerName.Length < minNameLen;
	}

	void proccessPlayerInput () {
		if (Input.GetKeyDown(KeyCode.Return) && !nameIsTooShort() ) {
			confirmName();
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
		while (true) {
			showingCursor = false;
            playerNameTextField.text = playerName;
            yield return new WaitForSeconds(.35f);
			showingCursor = true;
            playerNameTextField.text = playerName + "|";
            yield return new WaitForSeconds(.2f);
		}
	}
}
