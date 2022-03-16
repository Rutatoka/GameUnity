using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
    public GameObject Panel;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

    }
    private void Update()
    {
        player.scoreDisplayPause.text = "" + player.score;
        player.DisplayNamePause.text = "" + player.DisplayNameGame.text;

    }
    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void PauseGame()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResetGame()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }
   

}
