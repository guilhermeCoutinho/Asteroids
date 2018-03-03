using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[System.Serializable]
public class HighScore : MonoBehaviour {
	public GameObject highScoreAdapter;
	public int NumberOfEntriesToDisplay;
	public GameObject highScorePanel;

    List<HighScoreTuple> scores;

	string FilePath {
		get {
			return Application.persistentDataPath + "/scores.db";
		}
	}

	public void ShowHighScores (string name , int score) {
		returnAllObjectsToPool();
		LoadScore ();
		HighScoreTuple tuple = new HighScoreTuple (name,score);
		scores.Add (tuple);
		scores = scores.OrderByDescending(x => x.score).ToList();
		int playerPosition = scores.IndexOf(tuple);
		SaveScore ();
		instantiateAdapters(name, playerPosition);
	}

	void instantiateAdapters (string playerName, int playerPosition) {
		for (int i=0;i<NumberOfEntriesToDisplay && i < scores.Count;i++)
			instantiateAdapter(i,playerName,playerPosition);

		if (playerPosition >= NumberOfEntriesToDisplay)
            instantiateAdapter(playerPosition,playerName,playerPosition);
	}
	
	void instantiateAdapter (int position,string playerName,int playerPosition) {
		HighScoreTuple tuple = scores[position];
		HighScoreAdapter adapter = Instantiate(highScoreAdapter,
			highScorePanel.transform).GetComponent<HighScoreAdapter>();
        adapter.BindData(tuple.playerName,tuple.score,position,tuple.playerName == playerName,
            position == playerPosition);
	}

	void returnAllObjectsToPool () {
		for (int i = 0; i < highScorePanel.transform.childCount;i++)
			Destroy(highScorePanel.transform.GetChild(i).gameObject);
	}

	void SaveScore () {
		string json = JsonUtility.ToJson (new ListWapper(scores));
		File.WriteAllText (FilePath,json);
	}

	void LoadScore () {
		if (File.Exists(FilePath)) {
			try
			{
                string json = File.ReadAllText(FilePath);
				ListWapper wrapper = (ListWapper)JsonUtility.FromJson(json, typeof(ListWapper));
                scores = wrapper.highScores;
			}
			catch (System.Exception e)
			{
				print (e.StackTrace);
			}
		}else {
			scores = new List<HighScoreTuple>();
		}
	}
}

[System.Serializable] 
public struct ListWapper {
	 public List<HighScoreTuple> highScores; 

	 public ListWapper (List<HighScoreTuple> list){
		 highScores = list;
	 }
}