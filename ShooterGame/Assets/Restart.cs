using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Restart : MonoBehaviour
{

    private Player player;
  
    private void Start()
    {
        player = FindObjectOfType<Player>();
       
    }
    private void Update()
    {
        player.scoreDisplayDeath.text = "" + player.score;
        player.DisplayNameDeath.text = "" + player.DisplayNameDeath.text;


    }
    public void StartAgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1f;
    }
}
