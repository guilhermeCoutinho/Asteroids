using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HighScoreTuple
{
    public string playerName;
    public int score;

    public HighScoreTuple(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}