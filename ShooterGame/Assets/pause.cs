using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
    public GameObject PanelPause;
    public GameObject PanelDeath;
    private Player player;
    public Text textScore;
    public Text textName;


    private void Start()
    {
        //PanelDeath = GameObject.Find("deathPlayer");
        //PanelPause = GameObject.Find("pausePanel");
       
      
        player = FindObjectOfType<Player>();

    }

    private void Update()
    {
        //   player.scoreDisplayPause.text = "" + player.score;
        textScore.text = PlayerPrefs.GetInt("Score").ToString();
        textName.text = PlayerPrefs.GetString("Player");
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
