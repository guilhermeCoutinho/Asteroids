using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreAdapter : MonoBehaviour {

	public Color thisSessionColor ;
	public Color regularColor ;

	public Text nameTextField;
	public Text scoreTextField;
	public GameObject isPlayerScoreField;

	public void BindData (string playerName , int score, int position ,bool isPlayerScore,bool isSessionScore) {
		nameTextField.text = (position+1) + ". " + playerName;
		scoreTextField.text =  score.ToString();//.PadLeft(10,'0') ;
		isPlayerScoreField.SetActive (isSessionScore);
		nameTextField.color = isPlayerScore ? thisSessionColor : regularColor;
		scoreTextField.color = isPlayerScore ? thisSessionColor : regularColor;
		transform.SetAsLastSibling ();
	}

}
