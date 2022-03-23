using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LiderTable : MonoBehaviour
{
    private Player player;
    private int Score;
    private string NamePlayer;

    private void Start()
    {
       Score = player.score;
        NamePlayer = player.DisplayNameDeath.text;
        player = FindObjectOfType<Player>();
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", Score);
            PlayerPrefs.SetString("name", NamePlayer);

        }
        else
        {
            Score = PlayerPrefs.GetInt("score");
            NamePlayer = PlayerPrefs.GetString("name");

        }
    }
    private void Update()
    {
        player.scoreDisplayDeath.text = "" + Score;
        player.DisplayNameDeath.text = "" + NamePlayer;

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("score", Score);
        PlayerPrefs.SetString("name", NamePlayer);

    }
}
