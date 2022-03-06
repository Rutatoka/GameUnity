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
        player.scoreDisplayPanel.text = "" + player.score;
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
