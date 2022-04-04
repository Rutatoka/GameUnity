using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Restart : MonoBehaviour
{


    public Text[] textScore;
    public Text[] textName;
    public bool[] isFull;
 //   private int[] checkLiders;

    private void Start()
    {

    
    }
    private void Update()
    {
       
        for (int i =0; i<textScore.Length;i++)
        {

            if (isFull[i]==false)
            {
                isFull[i] = true;
                textScore[i].text = PlayerPrefs.GetInt("Score").ToString();
                textName[i].text = PlayerPrefs.GetString("playerName");
                break;
            }

        }
        //   player.scoreDisplayDeath.text = "" + player.score;
        // player.DisplayNameDeath.text = "" + player.DisplayNameDeath.text;


    }
    public void StartAgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1f;
    }
}
