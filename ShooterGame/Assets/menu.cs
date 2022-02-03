using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    /*  public void Start()
      {
          if (keyCode = KeyCode.A)
          {

          }
      }*/
}
