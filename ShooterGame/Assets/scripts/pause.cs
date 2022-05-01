using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
   // public PlayerInfo dataBase;

    public GameObject PanelPause;
    public GameObject PanelDeath;
   // private Player player;
    public Text textScore;
    public Text textName;
    //public Text textID;
    //private Text NameOfPlayer;
    //private Text IdOfPlayer;



    private void Start()
    {
        //  player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //PanelDeath = GameObject.Find("deathPlayer");
        //PanelPause = GameObject.Find("pausePanel");
        //    textName.text = player.DisplayName.text;
        // textID.text = player.DisplayID.text;
        //NameOfPlayer = GameObject.Find("NamePlayer").GetComponent<Text>();
        //IdOfPlayer = GameObject.Find("IdPlayer").GetComponent<Text>();
     //   textScore.text = PlayerPrefs.GetInt("Score").ToString();

    }
   
 
    private void Update()
    {
        
        //   player.scoreDisplayPause.text = "" + player.score;
       // textScore.text = PlayerPrefs.GetInt("Score").ToString();

        if (!PlayerPrefs.HasKey("playerName")&& !PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetString("playerName", "NoName");
        }

        else
        {
            textName.text = PlayerPrefs.GetString("playerName");
            textScore.text = PlayerPrefs.GetInt("Score").ToString();
        }
        //   player.DisplayNamePause.text = "" + player.DisplayNameGame.text;
        if (Input.GetKey(KeyCode.Space))
        {
            PauseGame();
        }
    }
    public void ExitGamePanel()
    { 
        PanelPause.SetActive(false);
        PanelDeath.SetActive(true);
      
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void ExitGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void PauseGame()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResetGame()
    {
        PanelPause.SetActive(false);
        Time.timeScale = 1f;
    }
   

}
