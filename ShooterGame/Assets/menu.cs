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
    private Text PlayerName;

    int saveNameGame = 0;

    private void Start()
    {
        PlayerName = GameObject.Find("NamePlayer").GetComponent<Text>();
    }
    private void Update()
    {
        if (inGame.text == "")
        {
            SaveNameButton.GetComponent<Button>().interactable = false;
          
        }
        else
        {
            SaveNameButton.GetComponent<Button>().interactable = true;
            if (saveNameGame==1)
            {
                playButton.GetComponent<Button>().interactable = true;

            }
        }

    }
 
    public void SaveName()
    {
        //if (PlayerName.text=="")
        //{
            PlayerName.text = inGame.text;
            saveNameGame = 1;
        //}
        //else
        //{
          
       // }
       

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
