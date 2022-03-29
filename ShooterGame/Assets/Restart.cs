using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Restart : MonoBehaviour
{


    public Text textScore;
    public Text textName;


    private void Start()
    {
      
       
    }
    private void Update()
    {
        textScore.text = PlayerPrefs.GetInt("Score").ToString();
        textName.text = PlayerPrefs.GetString("Player");

        //   player.scoreDisplayDeath.text = "" + player.score;
        // player.DisplayNameDeath.text = "" + player.DisplayNameDeath.text;


    }
    public void StartAgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1f;
    }
}
