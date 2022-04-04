using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public InputField inGame;
    public GameObject playButton;
    public GameObject SaveNameButton;
    public Text PlayerName;
    //  private string namePlayer;


    int saveNameGame = 0;

    private void Start()
    {

      //  PlayerName.text = inGame.text.ToString();
        inGame.GetComponent<Text>();
        //PlayerPrefs.SetString("playerName", inGame.text.ToString());
       
        //     PlayerPrefs.SetString("playerName", namePlayer);

        //   PlayerPrefs.Save();
    }
    private void Update()
    { 
        
       // PlayerName.text = PlayerPrefs.GetString("playerName");
        if (inGame.text == "")
        {
            SaveNameButton.GetComponent<Button>().interactable = false;
          
        }
        else
        {
           
            SaveNameButton.GetComponent<Button>().interactable = true;
           
            PlayerPrefs.SetString("playerName", inGame.text.ToString());
           

        

            if (saveNameGame==1)
            {
                playButton.GetComponent<Button>().interactable = true;

            }
        }

    }
 
    public void SaveName()
    {

        // PlayerName.text = PlayerPrefs.GetString("playerName");
        //   print(PlayerPrefs.GetString("playerName"));
        PlayerName.text = PlayerPrefs.GetString("playerName");
        Debug.Log(inGame.text.ToString());
            saveNameGame = 1;
     
    } 
    public void StartGame()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
         

    }
    public void OpenRules()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2 );
    }
    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

   
}
