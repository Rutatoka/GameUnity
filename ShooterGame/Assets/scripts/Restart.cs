using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[Serializable]
public class TableUser {
    public string name;
    public int score;
}

[Serializable]
public class ScoreTable {
    public List<TableUser> table;
}

public class Restart : MonoBehaviour
{


    public Text[] textScore;
    public Text[] textName;
    public bool[] isFull;

    private void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        var name = PlayerPrefs.GetString("playerName");
        AddToTable(name, score);
        var table = GetScoreTable();
        for (int i =0; i < table.table.Count;i++) 
        {
            textScore[i].text =table.table[i].score.ToString();
            textName[i].text = table.table[i].name;        
        }
    }
    public void StartAgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1f;
    }
    private void AddToTable( string playername, int score )
    {
        ScoreTable scoreTable = GetScoreTable(); 
        var index = scoreTable.table.FindIndex( user => user.name == playername);
        if (index >= 0) {
            var prevScore = scoreTable.table[index].score;
            if ( score > prevScore|| score==0 )
            {            
                scoreTable.table[index].score = score;
            }
        }
        else
        {
            scoreTable.table.Add( new TableUser{name = playername, score = score} );
        }
        var jsonString = JsonUtility.ToJson(scoreTable);
        PlayerPrefs.SetString("playerTable", jsonString);
        PlayerPrefs.Save();
    }
    private ScoreTable GetScoreTable()
    {
        var playerTableStr = PlayerPrefs.GetString("playerTable");
        ScoreTable scoreTable = JsonUtility.FromJson<ScoreTable>(playerTableStr);
        if (scoreTable == null || scoreTable.table == null) {
            scoreTable = new ScoreTable();
            scoreTable.table = new List<TableUser>();
        }
        return scoreTable;
    }
    public void ClearNames()
    {
        var table = GetScoreTable();
        PlayerPrefs.DeleteKey("playerTable");
        PlayerPrefs.DeleteKey("Score");
        for (int i = 0;  i < textScore.Length; i++)
        {
            textScore[i].text = " ";
            textName[i].text = " ";
        }
    }
}
